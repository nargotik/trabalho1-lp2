msbuild /p:Configuration=Release ITgestao.sln
mono ./packages/xunit.runners.*/tools/xunit.console.clr4.exe ./Tests/bin/Release/Tests.dll