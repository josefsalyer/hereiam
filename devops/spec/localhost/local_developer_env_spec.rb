require 'spec_helper_localhost'
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

  describe file(ENV["HOME"] + '/.gemrc'), :if => os[:family] == 'darwin' do
    it { should exist }
    it { should contain 'gem: --user-install'}
  end

  describe command('/usr/bin/mono --version'), :if => os[:family] == 'darwin' do
    its(:stdout) {should contain('Mono JIT compiler version 4.0.2') }
  end

  describe file("/Applications/Xamarin Studio.app"), :if => os[:family] == 'darwin' do
    it { should exist }
  end

  describe file(ENV["HOME"] + '/.gem/ruby/2.0.0/bin'), :if => os[:family] == 'darwin' do
    it { should exist }
  end

  describe command('echo $PATH'), :if => os[:family] == 'darwin' do
    its(:stdout) { should contain(ENV["HOME"] + '/.gem/ruby/2.0.0/bin') }
  end
end

