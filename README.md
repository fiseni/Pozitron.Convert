<h1 align="center">
<img src="pozitronlogo.png" width=15%>
</h1>

[![Build Status](https://dev.azure.com/pozitrongroup/PozitronDev.Convert/_apis/build/status/fiseni.PozitronDev.Convert?branchName=master)](https://dev.azure.com/pozitrongroup/PozitronDev.Convert/_build/latest?definitionId=5&branchName=master)
[![Azure DevOps coverage](https://img.shields.io/azure-devops/coverage/pozitrongroup/PozitronDev.Convert/5.svg)](https://dev.azure.com/pozitrongroup/PozitronDev.Convert/_build/latest?definitionId=5&branchName=master)

# PozitronDev Convert

Extensions to System.Object for inline conversion to various value types. Useful library for simplifying conversion tasks, considering all possible scenarios.

## Usage

The real benefit becomes obvious in desktop applications development, where controls might return object values. By using these extensions we can get some clean inline assignments.

```c#
    public void SetMinimumQuantity(object controlValue)
    {
    	var minQuantity = controlValue.To<double?>() ?? 1;

        // process some logic here
    }
```

## Give a Star! :star:
Please give it a star if you like or using the project. Thanks!

## Supported Extensions

- `object.To().StringOrEmpty`
- `object.To().StringOrNull`
- `object.To().Bool`
- `object.To().BoolOrNull`
- `object.To().BoolOrDefault`
- `object.To().Int`
- `object.To().IntOrNull`
- `object.To().IntOrDefault`
- `object.To().Long`
- `object.To().LongOrNull`
- `object.To().LongOrDefault`
- `object.To().Decimal`
- `object.To().DecimalOrNull`
- `object.To().DecimalOrDefault`
- `object.To().Double`
- `object.To().DoubleOrNull`
- `object.To().DoubleOrDefault`
- `object.To().DateTime`
- `object.To().DateTimeOrNull`
- `object.To().DateTimeOrDefault`

#### Short-hand notations

- `object.To<T>()` for `object.To().T`
- `object.To<T?>()` for `object.To().TOrNull`

e.g.
- `object.To<int>()` for `object.To().Int`
- `object.To<int?>()` for `object.To().IntOrNull`


