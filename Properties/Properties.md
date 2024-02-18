# Properties

Properties in C# are members that provide a flexible mechanism to read, write, or compute the values of private fields. Properties can be used as if they were public data members, but they actually include special methods called accessors. This primer will introduce you to the concepts of properties in C#, how to define them, and how to use them effectively.

## Understanding Properties

Properties in C# serve two main purposes:

1. **Encapsulation**: They encapsulate a private field, allowing you to protect the field by controlling read and write access through the `get` and `set` accessors.
2. **Data Validation**: Properties can include logic for validation, ensuring that data is consistent and meets certain criteria before assigning it to the field.

## Basic Syntax

A property has two accessors: `get` and `set`. The `get` accessor returns the property value, and the `set` accessor assigns a new value. This new value is accessed through the `value` keyword.

```C#
private int _myField;

public int MyProperty
{
    get { return _myField; }
    set { _myField = value; }
}
```

## Auto-Implemented Properties

If no additional logic is required in the property accessors, you can use auto-implemented properties for more concise syntax. The compiler automatically creates a private, anonymous field that can only be accessed through the property's `get` and `set` accessors.

```c#
public int MyProperty { get; set; }
```

## Read-Only and Write-Only Properties

- **Read-Only**: A property that includes only a `get` accessor.
- **Write-Only**: A property that includes only a `set` accessor. (Less common due to limited use cases.)

```C#
public int ReadOnlyProperty { get; }
public int WriteOnlyProperty { set; }
```

## Property Accessor Accessibility

You can define different accessibility levels for the `get` and `set` accessors to restrict read-write access. For example, you might want a property to be publicly readable but only writable within the class:

```C#
public int MyProperty { get; private set; }
```

## Using Properties

Properties are used just like fields when accessing from other parts of your code. You can read from and write to them (assuming both accessors are available) directly:

```C#
MyClass obj = new MyClass();
obj.MyProperty = 10; // Set value
int value = obj.MyProperty; // Get value
```

## Implementing Validation

Properties are ideal for implementing validation logic to ensure that the data is within acceptable parameters before setting a field:

```C#
private int _myField;
public int MyProperty
{
    get { return _myField; }
    set
    {
        if (value >= 0) // Validation condition
            _myField = value;
        else
            throw new ArgumentOutOfRangeException(nameof(value), "Value must be non-negative");
    }
}
```

## Conclusion

Properties in C# provide a powerful way to control access to class and struct data. By using properties, you can implement encapsulation and data validation within your types, improving the robustness and reliability of your applications. Whether you're using simple auto-implemented properties for straightforward data storage or implementing complex logic within your accessors, properties are an essential tool in the C# developer's toolkit.