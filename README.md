# Loan Decider

#### Usage

From the command line prompt type

`quote.exe $PATH_TO_MARKETDATA.CSV $AMOUNT_TO_LOAN`

`$PATH_TO_MARKETDATA.CSV` must be a valid CSV file containing the lenders and what they are lending.

`$AMOUNT_TO_LOAN` must be a integer between 1000 to 15000 in an increment of 100, representing the requested amount to borrow


### Assumptions

* A loan can only come from one lender.
* Lender loans are not pooled together to create a new loan.
* Should two lenders be able to lend a given request, the one with the lower interest rate will be returned
* Compound interest is based on the [annuity formula](https://en.wikipedia.org/wiki/Amortization_calculator#The_formula)
