$(() => {

    $("#car-type").on('input', function () {

        const carType = $("#car-type").val();
        console.log(carType);
        if (carType == 1) {
            $("#leather-seats").prop('checked', true);
            $("#leather-seats").prop('disabled', true);
            $("form").append("<input type='hidden' name='LeatherSeats' value='true' id='leather-hidden'/>")
        } else {
            $("#leather-seats").prop('disabled', false);
            $("#leather-hidden").remove();
        }
    });

    $("form").on('input', function () {

        const make = $("#make").val();
        const model = $("#model").val();
        const year = $("#year").val();
        const price = $("#price").val();
        const carType = $("#car-type").val();
        const leatherSeats = $("#leather-seats").val();
        const isValid = make && model && year && price && carType && leatherSeats;
        $("#submit-button").prop('disabled', !isValid);
    });












});