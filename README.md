## Synopsis

A set of helper functions to aid in argument validations.

## Motivation

The first few lines of any well behaved function should be argument validation. Fail fast, fail early is not only the motto in the startup world, but the same mantra works when writing a well groomed function. Once you set up the expectations and constraints it also narrows down the behaviour matrix that you need to test.  [Read more ...](https://medium.com/@rezaulhoque/proper-function-manners-and-etiquettes-1ea83d4a7562#.hk2muqabm) 


## Usage example

Check for Null or Empty

```C#
        public void AddPerson(string personId, Person personData)
        {
            Throw.IfNullOrEmpty(personId, nameof(personId));
            Throw.IfNull(personData, nameof(personData));
```

Check for condition

```C#
       public void Compute(int generation)
        {
            Throw.IfNot(() => generation > 100);
```

Check for range

```C#
        public void Compute(int generation)
        {
            Throw.IfOutOfRange(generation, 1, 100, nameof(generation));
```


## Installation

First, [install NuGet](http://docs.nuget.org/consume/installing-nuget). Then, install [Argument.Validator](https://www.nuget.org/packages/Argument.Validator/) from the package manager console:

```Install-Package Argument.Validator```

## Acknowledgments

A big thanks to [Olivia Ifrim](https://github.com/olivif) who helped craft the API requirements.
