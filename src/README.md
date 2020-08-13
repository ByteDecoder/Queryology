# Project Notes

## Running the test suite

Inside the *scr* directory execute:

```bash
./run-testsuite.sh
```

## .Net Core Format Tool

```bash
dotnet tool install -g dotnet-format
Tools directory '/<base_user>/.dotnet/tools' is not currently on the PATH environment variable.
If you are using zsh, you can add it to your profile by running the following command:

cat << \EOF >> ~/.zprofile
# Add .NET Core SDK tools
export PATH="$PATH:/<base_user>/.dotnet/tools"
EOF

And run `zsh -l` to make it available for current session.

You can only add it to the current session by running the following command:

export PATH="$PATH:/<base_user>/.dotnet/tools"
```
