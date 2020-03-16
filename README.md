<p align="center">
  <p align="center">
    <img src="https://user-images.githubusercontent.com/5221349/72841405-93c2ce80-3c96-11ea-844b-3e1ff782b1ae.png" height="100" alt="Blockcore" />
  </p>
  <h3 align="center">
    Blockcore Samples and Templates
  </h3>
</p>


### Introduction

This repository contains samples for building new blockchain applications and coins using the Blockcore platform. 

The samples can be copied directly or if you prefer you can install the Blockcore template and use `dotnet new` to create a new blockchain based on the sample. Using the template will substitute in the name of your blockchain and coin ticker.


### Template Usage

1) Install the template from nuget
```
dotnet new -i Blockcore.Coin.Template
```

2) Create a directory for your coin
```
~$  mkdir mynewcoin
~$  cd mynewcoin
```

3) Create your coin
```
~/mynewcoin$  dotnet new blockcorecoin --coinTicker MNC
```

4) Find all the "TODO" comments in the code for things that needs to be replaced before you can start you blockchain.

### Tasks

- [ ] Add unit tests to template
- [ ] Parameterize ports
- [ ] Parameterize magic number
- [ ] Parameterize pszTimestamp
- [ ] Optional features


