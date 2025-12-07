{
  pkgs ? import <nixpkgs> { },
}:

pkgs.mkShell {
  buildInputs = [
    pkgs.dotnet-sdk
    pkgs.omnisharp-roslyn
    pkgs.csharpier
    pkgs.doxygen
    pkgs.zig
    pkgs.gnumake

    pkgs.hyperfine
    # keep this line if you use bash
    pkgs.bashInteractive
  ];
}
