require 'spec_helper'

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

describe file(ENV["HOME"] + '/.gemrc'), :if => os[:family] == 'darwin' do
	it { should exist }
        it { should contain 'gem: --user-install'}
end

describe file(ENV["HOME"] + '/.gem/ruby/2.0.0/bin'), :if => os[:family] == 'darwin' do
  it { should exist }
end
