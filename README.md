<img align="left" src="pozitronlogo.png" width="120" height="120">

&nbsp; [![NuGet](https://img.shields.io/nuget/v/PozitronDev.Convert.svg)](https://www.nuget.org/packages/PozitronDev.Convert)[![NuGet](https://img.shields.io/nuget/dt/PozitronDev.Convert.svg)](https://www.nuget.org/packages/PozitronDev.Convert)

&nbsp; [![Build Status](https://dev.azure.com/pozitrondev/PozitronDev.Convert/_apis/build/status/fiseni.PozitronDev.Convert?branchName=master)](https://dev.azure.com/pozitrondev/PozitronDev.Convert/_build/latest?definitionId=3&branchName=master)

&nbsp; [![Azure DevOps coverage](https://img.shields.io/azure-devops/coverage/pozitrondev/PozitronDev.Convert/3.svg)](https://dev.azure.com/pozitrondev/PozitronDev.Convert/_build/latest?definitionId=3&branchName=master)

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

```c#
    public void ReadUserInputs()
    {
    	FirstName = FirstNameText.EditValue.To().StringOrEmpty;
        Quantity = QuantityText.EditValue.To().IntOrDefault;
        Price = PriceText.EditValue.To().Decimal;
        SortNo = SortNoText.EditValue.To<int>();
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


