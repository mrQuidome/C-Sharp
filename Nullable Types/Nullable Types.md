# Nullable Types

Nullable types in C# are a powerful feature that allows value types (such as `int`, `double`, `bool`, etc.) to hold `null` as a value. This feature is particularly useful when dealing with databases, APIs, or any scenarios where a value might not be present or is unknown. Here's a primer on how nullable types work in C#:

## Basics of Nullable Types

- **Definition**: In C#, value types cannot be `null` by default. Nullable types are instances of the `System.Nullable<T>` struct, which allows you to assign `null` to value type variables.
- **Syntax**: You can make a value type nullable by adding a `?` after the type name. For example, `int?` is a nullable integer, and `bool?` is a nullable boolean.

## Declaration and Initialization

```
int? nullableInt = null;
double? nullableDouble = 3.14;
bool? nullableBool = null;
```

- You can assign `null` or a valid value type to a nullable type variable.
- Initialization to `null` means the value is absent or unknown.

## Checking for Value

- Use the `.HasValue` property to check if the nullable type has a value:

  ```
  if (nullableInt.HasValue)
  {
      Console.WriteLine("Has value");
  }
  else
  {
      Console.WriteLine("No value");
  }
  ```

- You can also use the `== null` check.

## Accessing the Value

- Use the `.Value` property to access the actual value of a nullable type. Note: Accessing `.Value` when it is `null` will throw an `InvalidOperationException`.

  ```
  if (nullableInt.HasValue)
  {
      Console.WriteLine(nullableInt.Value);
  }
  ```

  

- Alternatively, the null-coalescing operator `??` can be used to provide a default value if `null`:

  ```
  int value = nullableInt ?? 0; // 0 if nullableInt is null
  ```

## Null-Coalescing and Null-Conditional Operators

- **Null-Coalescing (`??`)**: Returns the left-hand operand if the operand is not `null`; otherwise, it returns the right hand operand.

  ```
  int result = nullableInt ?? -1;
  ```

- **Null-Conditional (`?.`)**: Accesses a member of an object or executes a method if the object is not `null`. It returns `null` if the object is `null`.

  ```
  int? length = nullableString?.Length;
  ```

## Conversion and Boxing

- Implicit conversion exists from a nullable type to its underlying type, provided the nullable type is not `null`.
- Boxing a nullable type that is `null` results in a `null` reference. Otherwise, the value is boxed as if it were not a nullable type.

## Use Cases

- **Databases**: Representing a column that can be `NULL`.
- **Interoperability**: Working with APIs or libraries that can return `null` for value types.
- **Logic**: Signifying "no data" or "unknown" values in business logic.

Nullable types enhance the expressiveness of C# by allowing value types to represent the absence of a value. Understanding how to work with nullable types is crucial for scenarios where data might be optional or missing.