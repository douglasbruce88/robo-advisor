# Domain modelling

## What is the domain?

- People
- Time
- Money

## How can F# help us model it?

#### Algebraic Data Types

- Unions: `Bool`, `Option`, `Result`, Composite (binary tree), Wrappers (email address)
- Immutable records: concise syntax; structural equality

#### Pattern matching

- Type-safe `switch` alternative
- One-step match & decompose
- Compiler catches non-exhaustive `match`

#### Units of measure

- How do you represent a currency in code?
- Derived measures (*e.g* `kg m / s^2`)
- Reduce errors in conversions & calculations
  - How bad can this really be? Take a look [here](https://www.wired.com/2010/11/1110mars-climate-observer-report/)!

## Useful links

#### Talks

Scott Wlaschin NDC: https://vimeo.com/97507575

Tomas Petricek Channel 9: https://www.youtube.com/watch?v=Sa6bntNslvY

Mark Seeman NDC: https://vimeo.com/131631483


#### Blogs

http://fsharpforfunandprofit.com/ddd/

http://tomasp.net/blog/type-first-development.aspx/

http://gorodinski.com/blog/2013/02/17/domain-driven-design-with-fsharp-and-eventstore/
