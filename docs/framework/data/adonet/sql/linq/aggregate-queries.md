---
title: Aggregate queries
ms.date: "03/30/2017"
ms.assetid: 13ec5580-05ce-4a1f-9d3d-8660be7891a2
---
# Aggregate queries

[!INCLUDE[vbtecdlinq](../../../../../../includes/vbtecdlinq-md.md)] supports the `Average`, `Count`, `Max`, `Min`, and `Sum` aggregate operators. Note the following characteristics of aggregate operators in [!INCLUDE[vbtecdlinq](../../../../../../includes/vbtecdlinq-md.md)]:

- Aggregate queries are executed immediately.

    For more information, see [Introduction to LINQ Queries (C#)](../../../../../csharp/programming-guide/concepts/linq/introduction-to-linq-queries.md).

- Aggregate queries typically return a number instead of a collection.

    For more information, see [Aggregation Operations](https://docs.microsoft.com/previous-versions/visualstudio/visual-studio-2013/bb546138(v=vs.120)).

- You cannot call aggregates against anonymous types.

The examples in the following topics derive from the Northwind sample database. For more information, see [Download sample databases](downloading-sample-databases.md).

## In this section

- [Return the average value from a numeric sequence](return-the-average-value-from-a-numeric-sequence.md)

  Demonstrates how to use the <xref:System.Linq.Enumerable.Average%2A> operator.

- [Count the number of elements in a sequence](count-the-number-of-elements-in-a-sequence.md)

  Demonstrates how to use the <xref:System.Linq.Enumerable.Count%2A> operator.

- [Find the maximum value in a numeric sequence](find-the-maximum-value-in-a-numeric-sequence.md)

  Demonstrates how to use the <xref:System.Linq.Enumerable.Max%2A> operator.

- [Find the ةinimum value in a numeric sequence](find-the-minimum-value-in-a-numeric-sequence.md)

  Demonstrates how to use the <xref:System.Linq.Enumerable.Min%2A> operator.

- [Compute the sum of values in a numeric sequence](compute-the-sum-of-values-in-a-numeric-sequence.md)  

  Demonstrates how to use the <xref:System.Linq.Enumerable.Sum%2A> operator.

## Related sections

- [Query examples](query-examples.md)

  Provides links to [!INCLUDE[vbtecdlinq](../../../../../../includes/vbtecdlinq-md.md)] queries in Visual Basic and C#.

- [Query concepts](query-concepts.md)

  Provides links to topics that explain concepts for designing [!INCLUDE[vbteclinq](../../../../../../includes/vbteclinq-md.md)] queries in [!INCLUDE[vbtecdlinq](../../../../../../includes/vbtecdlinq-md.md)].

- [Introduction to LINQ Queries (C#)](../../../../../csharp/programming-guide/concepts/linq/introduction-to-linq-queries.md)

  Explains how queries work in [!INCLUDE[vbteclinq](../../../../../../includes/vbteclinq-md.md)].
