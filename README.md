# noonc

### Overview

noonc is a compiler for a programming language inspired by Clojure, Haskell, and Go. It
utilizes the [QBE compiler](https://c9x.me/compile/) as its backend to provide a complete pipeline from source code
to native executable.

### Installation

* Install dependencies:
    * Any C compiler (gcc, clang, zig, etc.)

#### Binary Installation

* Download `noonc` from GitHub releases.

#### Build from source

* Clone this repository and build `noonc` with the `dotnet-sdk`

### Usage

1. Write your source code in the `noon-lang` language.
2. Compile the source code using the `noonc` compiler.
3. The compiled code will be available in the `bin` directory.

### Features

* Complete compiler pipeline from source code to executable code.
* Supports features like:
    * Recursion
* Modular design for easy extension and customization.

### License

This project is licensed under the GNU General Public License version 3 (GPLv3).
See the LICENSE file for details.

### Contributing

Contributions are welcome! But please note this is a hobby project and my time is limited.

### Additional Notes:

* This project is not a professionally developed product.
* It is intended primarily for personal use and learning purposes.
* While contributions are welcome, the developer is under no obligation to provide support or accept pull requests.
* This project utilizes the [QBE compiler](https://c9x.me/compile/) as its backend.

