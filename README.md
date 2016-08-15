## Motivation

A set of helper functions to do argument validations.

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
       public void Compute(int value)
        {
            Throw.IfNot(() => value > 100);
```

Check for range

```C#
        public void Compute(int value)
        {
            Throw.IfOutOfRange(value, 1, 100, nameof(value));
```


## Installation

First, [install NuGet](http://docs.nuget.org/consume/installing-nuget). Then, install [Argument.Validator](https://www.nuget.org/packages/Argument.Validator/) from the package manager console:

```Install-Package Argument.Validator```

