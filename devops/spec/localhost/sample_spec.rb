require 'spec_helper'

describe file('/usr/bin/xcodebuild'), :if => os[:family] == 'darwin' do
  it { should exist }
end

