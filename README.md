## Motivation

A set of helper functions to do argument validations.

## Usage example

```C#
        public void AddPerson(string personId, Person personData)
        {
            Throw.IfNullOrEmpty(personId, nameof(personId));
            Throw.IfNull(personData, nameof(personData));
```

## Installation

First, [install NuGet](http://docs.nuget.org/consume/installing-nuget). Then, install [Argument.Validator](https://www.nuget.org/packages/Argument.Validator/) from the package manager console:

```Install-Package Argument.Validator```

