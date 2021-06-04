function addToCartOneQuantity(id, title) {
    document.getElementById("titleMessage").innerText = title;
    let toastElList = [].slice.call(document.querySelectorAll('.toast'));
    let toastList = toastElList.map(function (toastEl) {
        return new bootstrap.Toast(toastEl)
    });
    toastList.forEach(toast => toast.show());
    let cart = getCookie("cart");
    if (cart != "") {
        cart = JSON.parse(cart);
        cart = sortArrayCart(cart);
        let indexBook = binarySearchCart(cart, id);
        if(indexBook != -1)
        {
            let book = cart[indexBook];
            if (book["bookId"] == id) {
                book["quantity"] += 1;
                if (book["quantity"] > 10) book["quantity"] = 10;
            }
        }
        else
        {
            cart.push({ bookId: id, quantity: 1 });
        }
    }
    else {
        cart = [];
        cart.push({ bookId: id, quantity: 1 });
    }
    setCookie("cart", JSON.stringify(cart), 1);
}
function addToCart(id, title) {
    document.getElementById("titleMessage").innerText = title;
    var toastElList = [].slice.call(document.querySelectorAll('.toast'));
    var toastList = toastElList.map(function (toastEl) {
        return new bootstrap.Toast(toastEl)
    });
    toastList.forEach(toast => toast.show());
    let cart = getCookie("cart");
    if (cart != "") {
        cart = JSON.parse(cart);
        let exists = false;
        cart.forEach(book => {
            if (book["bookId"] == id) {
                book["quantity"] += parseInt($("#quantity").val());
                if (book["quantity"] > 10) book["quantity"] = 10;
                exists = true;
                return 0;
            }
        });
        if (!exists) {
            cart.push({ bookId: id, quantity: parseInt($("#quantity").val()) });
        }
    }
    else {
        cart = [];
        cart.push({ bookId: id, quantity: parseInt($("#quantity").val()) });
    }
    setCookie("cart", JSON.stringify(cart), 1);
}
async function getAllProductsInCart() {
    let cart = getCookie("cart");
    if (cart != "") {
        let price = 0;
        cart = JSON.parse(cart);
        if (cart.length == 0) {
            document.getElementById("totalPrice").innerText = (0).toFixed(2);
            document.getElementById("finishOrderButton").style = "display: none;";
            document.getElementById("emptyCart").style = "";
        }
        let cartElement = document.getElementById("cart");
        cartElement.innerHTML = "";
        for (let i = 0; i < cart.length; i++) {
            await $.get(`../Book/getBookByIdJson/${cart[i]["bookId"]}`, function (data) {
                price += data["price"] * cart[i]["quantity"];
                cartElement.innerHTML += `<tr id="item${cart[i]["bookId"]}">
    
                <td><a href="../Book/${cart[i]["bookId"]}">${data["title"]}</a></td><td><div class="input-group mt-3 mb-3" style="max-width: 120px;">
                <span class="input-group-prepend">
                    <button type="button" class="btn btn-outline-primary btn-number" data-type="minus" data-field="quant${cart[i]["bookId"]}[${cart[i]["quantity"]}]">
                        <span class="fas fa-minus"></span>
                    </button>
                </span>
                <input type="text" name="quant${cart[i]["bookId"]}[${cart[i]["quantity"]}]" id="quantity${cart[i]["bookId"]}" class="form-control input-number" value="${cart[i]["quantity"]}" min="1" max="10">
                <span class="input-group-append">
                    <button type="button" class="btn btn-outline-primary btn-number" data-type="plus" data-field="quant${cart[i]["bookId"]}[${cart[i]["quantity"]}]">
                        <span class="fas fa-plus"></span>
                    </button>
                </span>
            </div></td>
                <td>€ ${(data["price"] * cart[i]["quantity"]).toFixed(2)}</td>
                <td><i class="fas fa-trash-alt text-danger" onclick="deleteFromShoppingCart(${cart[i]["bookId"]})"></i></td>
                </tr>`;
            });
        }
        document.getElementById("totalPrice").innerText = price.toFixed(2);
        $('.btn-number').click(function (e) {
            e.preventDefault();

            fieldName = $(this).attr('data-field');
            type = $(this).attr('data-type');
            var input = $("input[name='" + fieldName + "']");
            var currentVal = parseInt(input.val());
            if (!isNaN(currentVal)) {
                if (type == 'minus') {

                    if (currentVal > input.attr('min')) {
                        input.val(currentVal - 1).change();
                    }
                    if (parseInt(input.val()) == input.attr('min')) {
                        $(this).attr('disabled', true);
                    }

                } else if (type == 'plus') {

                    if (currentVal < input.attr('max')) {
                        input.val(currentVal + 1).change();
                    }
                    if (parseInt(input.val()) == input.attr('max')) {
                        $(this).attr('disabled', true);
                    }

                }
            } else {
                input.val(0);
            }
        });
        $('.input-number').focusin(function () {
            $(this).data('oldValue', $(this).val());
        });
        $('.input-number').change(function () {

            minValue = parseInt($(this).attr('min'));
            maxValue = parseInt($(this).attr('max'));
            valueCurrent = parseInt($(this).val());

            name = $(this).attr('name');
            if (valueCurrent >= minValue) {
                $(".btn-number[data-type='minus'][data-field='" + name + "']").removeAttr('disabled')
            } else {
                $(this).val(1);
            }
            if (valueCurrent <= maxValue) {
                $(".btn-number[data-type='plus'][data-field='" + name + "']").removeAttr('disabled')
            } else {
                $(this).val(10);
            }
        });

        $(".input-number").keydown(function (e) {
            if ($.inArray(e.keyCode, [46, 8, 9, 27, 13, 190]) !== -1 ||
                (e.keyCode == 65 && e.ctrlKey === true) ||
                (e.keyCode >= 35 && e.keyCode <= 39)) {
                return;
            }
            if ((e.shiftKey || (e.keyCode < 48 || e.keyCode > 57)) && (e.keyCode < 96 || e.keyCode > 105)) {
                e.preventDefault();
            }
        });
    }
    else {
        document.getElementById("totalPrice").innerText = (0).toFixed(2);
        document.getElementById("finishOrderButton").style = "display: none";
        document.getElementById("emptyCart").style = "";
    }
}
function deleteFromShoppingCart(id) {
    let cart = getCookie("cart");
    if (cart != "") {
        cart = JSON.parse(cart);
        for (let index = 0; index < cart.length; index++) {
            if (cart[index]["bookId"] == id) {
                cart.splice(index, 1);
            }
        }
        setCookie("cart", JSON.stringify(cart), 1);
        location.reload();
    }
}
function updateShoppingCart() {
    let cart = getCookie("cart");
    if (cart != "") {
        cart = JSON.parse(cart);
        for (let index = 0; index < cart.length; index++) {
            cart[index]["quantity"] = $(`#quantity${cart[index]["bookId"]}`).val();

        }
        setCookie("cart", JSON.stringify(cart), 1);
        location.reload();
    }
}
function finishOrder() {
    let cart = getCookie("cart");
    if (cart != "") {
        cart = JSON.parse(cart);
        if (cart.length != 0) {
            let isChecked = true;
            let isDigit = /^\d+$/;
            if ($("#address").val().length < 4) {
                isChecked = false;
            }
            if ($("#city").val().length < 4) {
                isChecked = false;
            }
            if ($("#phoneNumber").val().length < 10 || $("#phoneNumber").val().charAt(0) != '0' || !isDigit.test($("#phoneNumber").val())) {
                isChecked = false;
            }
            if (isChecked) {
                let booksAndQuantity = "{";
                cart.forEach(item => {
                    booksAndQuantity += `"${item["bookId"]}":${item["quantity"]}, `;
                });
                booksAndQuantity += "}";
                $.post("/Order/CreateOrder", {Address: $("#address").val(), City: $("#city").val(), PhoneNumber: $("#phoneNumber").val(), Notes: $("#notes").val(), BooksAndQuantity:booksAndQuantity}, function (result) {
                setCookie("cart", "", 1);
                window.location.href = "/Order/OrderSuccess";
                });
            }
        }
    }
}