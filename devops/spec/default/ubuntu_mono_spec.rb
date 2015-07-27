require 'spec_helper'

describe package('nginx'), :if => os[:family] == 'ubuntu' do
  it { should be_installed }
end

describe file('/var/www/hereiam') do
  it { should exist }
  it { should be_directory }
end 

# add the nginx config to available sites
describe file('/etc/nginx/sites-available/hereiam') do
  it { should exist }
  it { should be_file }
end 




#setup mono environmnet
describe package('mono-devel'), :if => os[:family] == 'ubuntu' do
	it { should be_installed}
end

describe package('mono-complete'), :if => os[:family] == 'ubuntu' do
	it { should be_installed}
end

describe command('mono --version'), :if => os[:family] == 'ubuntu' do
	its(:stdout) { should contain('Mono JIT compiler version 4.0.2') }
end


#compile the app and run it

# start the app
describe port(4567), :if => os[:family] == 'ubuntu' do
  it { should be_listening }
end



# start nginx
describe port(80), :if => os[:family] == 'ubuntu' do
  it { should be_listening }
end

