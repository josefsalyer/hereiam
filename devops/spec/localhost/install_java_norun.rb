require 'spec_helper'
require 'rspec/expectations'
describe "java environment" do
  

  describe file('./scripts/install_java.sh'), :if => os[:family] == 'darwin' do
  	it {should exist}
  	it {should be_mode 744}
  end

  describe command('./scripts/install_java.sh download'), :if => os[:family] == 'darwin' do
  	its(:stderr) { should contain '57.7M'}
    
  end

  describe file('/tmp/jre-8u51-macosx-x64.dmg'), :if => os[:family] == 'darwin' do
    it {should exist}
    its(:sha256sum) {should eq '713520b178dc2e044a1eb4d2275e65635d9449dc2290b123d6c73d2af3f4b8e2'}
  end

  describe command('./scripts/install_java.sh mount'), :if => os[:family] == 'darwin' do
    its(:stdout) { should contain '/Volumes/Java 8 Update 51' }
  end

  describe command('sudo ./scripts/install_java.sh install'), :if => os[:family] == 'darwin' do

    its(:stdout) { should contain 'successful.' }

  end

  # # check to make sure java works
  describe command('/usr/bin/java -version'), :if => os[:family] == 'darwin' do
    its(:stderr) {should contain('java version "1.8.0_45"') }
  end

  # 
  # its(:stdout) { should contain('installing java')}
  #   
  #   its(:stdout) { should contain '/Volumes/Java 8 Update 51' }


end