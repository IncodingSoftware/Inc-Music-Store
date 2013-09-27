
require 'albacore'
require 'fileutils'


def CreateDirIfNotExists(path)
  if !Dir.exist?(path)
    FileUtils.mkdir(path)
  end
end

def DeleteDirIfExists(path)
  if Dir.exist?(path)
    FileUtils.remove_dir(path)
  end
end

def DeleteFileIfExists(path)
  if File.exist?(path)
    File.delete(path)
  end
end

def manage(service, action, total_tries = 1, tries=0)
    begin
      sh "net #{action} #{service}"
      rescue
      tries +=1
      puts "Caught error while performing #{action} on #{service}"
      return if (tries == total_tries)
      puts "Next try to #{action} the #{service} in 30 seconds"
      sleep(30)
      manage(action, tries) unless (tries >= total_tries)
    end
end




dependencyFileList = [                     ]      # What file grab from folder Lib to publish


Environment =      {        :solution_name =>  ENV['solution_name']      	}



Folder =
    {
        :src =>'src',
        :config => File.join('config' , 'ci'),
        :deploy => 'deploy',
        :live =>  File.join('deploy' , 'Live'),
        :dev =>  File.join( 'deploy' , 'Dev'),		
        :prePublish => 'Deploy/Dev/_PublishedWebsites/'+ Environment[:solution_name]  +'.UI/*', # relative path to folder with publish site.
        :lib => 'src/Lib/*',
	    :mspecResult =>  File.join('deploy','MspecReport'),        
		:iis => ENV['iis_folder']	
    }

Files  =
    {
    :packageLive =>   Environment[:solution_name] + '.zip', 
    :sln =>  Environment[:solution_name] +  '.sln', #path to solution
    :mspecRunner =>  'tools/m-spec/mspec-clr4.exe', #path to mspec console runner
    :integratedTestDll =>     Folder[:dev] + '/'+ Environment[:solution_name] +'.UnitTest.dll',  #path to test dll
	:dbConfig => Folder[:config] + '/'  + 'db.config'
}








task :estblish do

  puts 'Show all global variable'

  puts Environment[:solution_name]

  puts Folder[:src]
  puts Folder[:deploy]
  puts Folder[:live]
  puts Folder[:dev]
  puts Folder[:prePublish]
  puts Folder[:lib]
  puts Folder[:mspecResult]
  puts Folder[:iis]

  puts Files[:packageLive]
  puts Files[:sln]
  puts Files[:mspecResult]
  puts Files[:integratedTestDll]
  puts Files[:dbConfig]



  puts 'Estblish. Create,remove folders and files'
  
  manage('w3svc','stop', 1)
  DeleteDirIfExists(Folder[:deploy])
  CreateDirIfNotExists(Folder[:deploy])
  CreateDirIfNotExists(Folder[:live])
  CreateDirIfNotExists(Folder[:iis])
  manage('w3svc','start', 1)
end

desc    'Clean and Build solution'
msbuild :build do |msb|
  msb.properties :configuration => :Release, :OutputPath => :"../../#{Folder[:dev]}"
  msb.targets :Clean,:Build
  msb.solution = File.join(Folder[:src],Files[:sln])
end

desc 'Execute integrated test'
mspec do |mspec|
  CreateDirIfNotExists(Folder[:mspecResult])
  FileUtils.cp_r(File.expand_path(Files[:dbConfig]),Folder[:dev],:verbose => true)  
  mspec.command = Files[:mspecRunner]
  mspec.assemblies Files[:integratedTestDll]
  mspec.html_output = Folder[:mspecResult]
end

desc 'Copy all dependency from folder lib to target folder'
task :resolveDependency do
  Dir[Folder[:lib]].each do |f|
    baseName = File.basename(f)
    if dependencyFileList.include?(baseName)
      folderBinInLive = "#{Folder[:live]}/bin"
      CreateDirIfNotExists(folderBinInLive)
      FileUtils.cp_r(File.expand_path(f), folderBinInLive,:verbose => true);
    end
  end
end

desc 'Copy files to publish folder from pre publish folder'
task :publish =>[:mspec,:resolveDependency]  do
 Dir[Folder[:prePublish]].each do |f|
   FileUtils.cp_r(File.expand_path(f),Folder[:live],:verbose => true)
 end
 FileUtils.cp_r(File.expand_path(Files[:dbConfig]),Folder[:live],:verbose => true)

end

desc 'Package artifacts to TeamCity'
zip:packageArtifacts do |zip|
  zip.directories_to_zip Folder[:live]
  zip.output_file = "../#{Files[:packageLive]}"
end

desc 'Copy file to iis web site directory'
task:publiishToIss do
  if Dir.exist?(Folder[:iis])
    FileUtils.rm_r(Dir[Folder[:iis] + '/*'],:verbose => true)
    FileUtils.cp_r(Dir[Folder[:live] +'/*'], Folder[:iis],:verbose => true)	
  end      
end


task :default => [:estblish,:build,:publish,:packageArtifacts,:publiishToIss] do
end





