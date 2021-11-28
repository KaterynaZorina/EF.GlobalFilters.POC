# EF.GlobalFilters.POC
This repository contains an example of EF.Core global query filters usage

#### Global query filters can be set using Fluent API, e.g.
```modelBuilder.Entity<CreditCard>().HasQueryFilter(c => c.IsActive);```

#### In case if global query filter should be disabled for some specific query, it can be simply achieved by using ```.IgnoreQueryFilters()``` method, e.g.:
```
_filtersDbContext
  .CreditCards
  .IgnoreQueryFilters()
  .AsQueryable();
```
