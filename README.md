<p align="center">
  <p align="center">
    <img src="https://user-images.githubusercontent.com/5221349/72841405-93c2ce80-3c96-11ea-844b-3e1ff782b1ae.png" height="100" alt="Blockcore" />
  </p>
  <h3 align="center">
    Blockcore Samples and Templates
  </h3>
  <p align="center">
      <a href="https://github.com/block-core/blockcore-samples/actions"><img src="https://github.com/block-core/blockcore-samples/workflows/Build/badge.svg" /></a>
  </p>
</p>

# Create your own Blockchain

The right place to get started, is this repository: https://github.com/block-core/blockcore-node

## Introduction to our "dotnet new" template

This repository contains samples for building new blockchain applications and coins using the Blockcore platform. 

The samples can be copied directly or if you prefer you can install the Blockcore template and use `dotnet new` to create a new blockchain based on the sample. Using the template will substitute in the name of your blockchain and coin ticker.

## Template Usage

1) Install the template from nuget
```
dotnet new -i Blockcore.Coin.Template
```

2) Create a directory for your coin
```
mkdir mynewcoin
cd mynewcoin
```

3) Create your coin
```
dotnet new blockcorecoin --coinTicker MNC .....
```

There are many parameters you need to specify, so find examples here:

[https://github.com/block-core/blockcore-nodes/tree/master/scripts](https://github.com/block-core/blockcore-nodes/tree/master/scripts)

4) Find all the "TODO" comments in the code for things that needs to be replaced before you can start you blockchain.

### Tasks

- [ ] Add unit tests to template
- [ ] Parameterize ports
- [ ] Parameterize magic number
- [ ] Parameterize pszTimestamp
- [ ] Optional features

### Template Development

Install locally can be done by navigating into the "Blockcore.SampleCoin" sub-folder and running the following command:
```
dotnet new -i .
```

Then you can create a new project like instructed above.

Also consider using the "-o" (--output) switch to easier quickly generate many instances for testing:

```
dotnet new blockcorecoin -c BTC -o CoinOne
```

### Linux

To use the sample coin template on Linux, first install the .NET Core SDK:

```
sudo snap install dotnet-sdk --classic
sudo snap alias dotnet-sdk.dotnet dotnet
```

Then clone the repository to a folder:

```
git clone https://github.com/block-core/blockcore-samples.git
```

Navigate into correct folder and install the template:
```
# Navigate to sample code

cd blockcore-samples
cd Blockcore.SampleCoin

# Install the sample code as a "dotnet new" template
dotnet new -i .
```

Navigate to your blockchain folder where you want to generate code:

```
dotnet new blockcorecoin --output MyCoin
cd MyCoin
```

Edit your code, with Visual Studio Code or another editor.

Now run and test your custom blockchain:

```
cd src
cd MyCoin.Node
dotnet run
```
