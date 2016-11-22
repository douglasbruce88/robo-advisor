namespace DomainModelling

module Domain =
  open System 

  type Gender = Male | Female

  type EmailAddress = EmailAddress of string

  type Person = { 
      Name : string
      Gender : Gender
      DateOfBirth : DateTime
      EmailAddress : EmailAddress option }

  type ContributionFrequency = Monthly | Annual

  type ContributionSchedule<[<Measure>] 'ccy> = {
      Amount : decimal<'ccy>
      Frequency : ContributionFrequency }
  
  type PensionPot<[<Measure>] 'ccy> = { 
      Value : decimal<'ccy>; 
      ValuationDate : DateTime; 
      ContributionSchedule: ContributionSchedule<'ccy> }

  [<Measure>] type GBP
  [<Measure>] type USD
  [<Measure>] type EUR

  let valuePensionPot<[<Measure>] 'ccy> (pensionPot : PensionPot<'ccy>) (valuationDate: DateTime) = 
     match pensionPot.ContributionSchedule.Frequency with 
     | Monthly ->
        let monthsInFuture = (valuationDate.Year - pensionPot.ValuationDate.Year) * 12 + valuationDate.Month - pensionPot.ValuationDate.Month
        pensionPot.Value + decimal monthsInFuture * pensionPot.ContributionSchedule.Amount
     | Annual ->
        let yearsInFuture = valuationDate.Year - pensionPot.ValuationDate.Year
        pensionPot.Value + decimal yearsInFuture * pensionPot.ContributionSchedule.Amount

module ThisWorks =

    module Node =
        type Node<'a> =
            | Node2 of 'a * 'a
            | Node3 of 'a * 'a * 'a

        let toList = function
            | Node2(a, b) -> [a; b]
            | Node3(a, b, c) -> [a; b; c]

    module Digit =
        type Digit<'a> =
            | One of 'a
            | Two of 'a * 'a
            | Three of 'a * 'a * 'a
            | Four of 'a * 'a * 'a * 'a

        let toList = function
            | One a -> [a]
            | Two(a, b) -> [a; b]
            | Three(a, b, c) -> [a; b; c]
            | Four(a, b, c, d) -> [a; b; c; d]

    module FingerTree =
        open Node
        open Digit

        type FingerTree<'a> =
            | Empty
            | Single of 'a
            | Deep of Digit<'a> * Lazy<FingerTree<Node<'a>>> * Digit<'a>

        let rec toSeq<'a> (tree:FingerTree<'a>) : seq<'a> = seq {
            match tree with
            | Single single ->
                yield single
            | Deep(prefix, Lazy deeper, suffix) ->
                yield! prefix |> Digit.toList
                yield! deeper |> toSeq |> Seq.collect Node.toList
                yield! suffix |> Digit.toList
            | Empty -> ()
        }

module ThisDoesnt =

    module Monoids =
        type IMonoid<'m> =
            abstract Zero:'m
            abstract Plus:'m -> 'm

        type IMeasured<'m when 'm :> IMonoid<'m>> =
            abstract Measure:'m

        type Size(value) =
            new() = Size 0

            member __.Value = value

            interface IMonoid<Size> with
                member __.Zero = Size()
                member __.Plus rhs = Size(value + rhs.Value)

        type Value<'a> =
            | Value of 'a

            interface IMeasured<Size> with
                member __.Measure = Size 1

    open Monoids

    module Node =
        type Node<'m, 'a when 'm :> IMonoid<'m>> =
            | Node2 of 'm * 'a * 'a
            | Node3 of 'm * 'a * 'a * 'a

        let toList = function
            | Node2(_, a, b) -> [a; b]
            | Node3(_, a, b, c) -> [a; b; c]

    module Digit =
        type Digit<'m, 'a when 'm :> IMonoid<'m>> =
            | One of 'a
            | Two of 'a * 'a
            | Three of 'a * 'a * 'a
            | Four of 'a * 'a * 'a * 'a

        let toList = function
            | One a -> [a]
            | Two(a, b) -> [a; b]
            | Three(a, b, c) -> [a; b; c]
            | Four(a, b, c, d) -> [a; b; c; d]

    module FingerTree =
        open Node
        open Digit

        type FingerTree<'m, 'a when 'm :> IMonoid<'m>> =
            | Empty
            | Single of 'a
            | Deep of 'm * Digit<'m, 'a> * Lazy<FingerTree<'m, Node<'m, 'a>>> * Digit<'m, 'a>

        let unpack (Value v) = v

        let rec toSeq<'a> tree : seq<'a> = seq {
            match tree with
            | Single(Value single) ->
                yield single
            | Deep(_, prefix, Lazy deeper, suffix) ->
                yield! prefix |> Digit.toList |> List.map unpack

                //let t1 =  toSeq deeper
                let t2 = toSeq deeper
                                 
                //#endif

                yield! suffix |> Digit.toList |> List.map unpack
            | Empty -> ()
        }