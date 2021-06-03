# ShoppingBasket_BuilderPattern
ShoppingBasket with Xunit and Repository Pattern, Builder Pattern to create shopping Basket


Shopping Basket Discount Task
 
Requirements
The company issues two types of voucher for customers to gain discounts on shopping baskets.

Gift Voucher:

Can be redeemed against the value of a basket.
Multiple gift vouchers can be applied to a basket.
Gift vouchers can only be redeemed against non gift voucher products.
The purchase of a gift voucher does not contribute to the discountable basket total.
Offer vouchers:

Requires a threshold that needs to be exceeded before a discount can be applied e.g. £5.00 off of baskets over £50.
Only a single offer voucher can be applied to a basket.
Can be applicable to only a subset of products.
Offer and Gift vouchers can be used in conjunction. If a customer applies an offer voucher to a basket that will not satisfy the threshold or a customer removes item/changes an items quantity resulting in a voucher not being valid then a message will need to be displayed to the customer.

Write an application that represents a basket and has the ability to handle the following scenarios:

Basket 1:
1 Jumper @ £54.65

1 Head Light (Head Gear Category of Product) @ £3.50

Sub Total: £58.15

No vouchers applied

Total: £58.15

Basket 2:
1 Gloves @ £10.50

1 Jumper @ £54.65

Sub Total: £65.15

1 x £5.00 Gift Voucher XXX-XXX applied

Total: £60.15

Basket 3:
1 Gloves @ £25.00

1 Jumper @ £26.00

Sub Total: £51.00

1 x £5.00 off Head Gear in baskets over £50.00 Offer Voucher YYY-YYY applied

Total: £51.00

Message: “There are no products in your basket applicable to Offer Voucher YYY-YYY.”

Basket 4:
1 Gloves @ £25.00

1 Jumper @ £26.00

1 Head Light (Head Gear Category of Product) @ £3.50

Sub Total: £54.50

1 x £5.00 off Head Gear in baskets over £50.00 Offer Voucher YYY-YYY applied

Total: £51.00

Basket 5:
1 Gloves @ £25.00

1 Jumper @ £26.00

Sub Total: £51.00

1 x £5.00 Gift Voucher XXX-XXX applied

1 x £5.00 off baskets over £50.00 Offer Voucher YYY-YYY applied

Total: £41.00

Basket 6:
1 Gloves @ £25.00

1 £30 Gift Voucher @ £30.00

Sub Total: £55.00

1 x £5.00 off baskets over £50.00 Offer Voucher YYY-YYY applied

Total: £55.00

Message: “You have not reached the spend threshold for Gift Voucher YYY-YYY. Spend another £25.01 to receive £5.00 discount from your basket total.”

Basket 7:
1 Gloves @ £25.00

Sub Total: £25.00

1 x £30.00 Gift Voucher XXX-XXX applied

Total: £0.00
