require 'spec_helper'
require 'rspec/expectations'

$whoami = `whoami`.chomp!


describe "local environment" do
  describe file('/usr/bin/xcodebuild'), :if => os[:family] == 'darwin' do
    it { should exist }
  end

  describe file('/usr/bin/git'), :if => os[:family] == 'darwin' do
    it { should exist }
  end

  describe command('git config --list'), :if => os[:family] == 'darwin' do
    its(:stdout) { should contain('user.name') }
    its(:stdout) { should contain('user.email') }
  end

  describe file("/Users/#{$whoami}/.ssh/id_rsa.pub"), :if => os[:family] == 'darwin' do
    it { should exist }
  end

  describe command('java -version'), :if => os[:family] == 'darwin' do
    its(:stdout) {should contain('java version "1.8.0_45"') }
  end

  describe file(ENV["HOME"] + '/.gemrc'), :if => os[:family] == 'darwin' do
    it { should exist }
    it { should contain 'gem: --user-install'}
  end
end
