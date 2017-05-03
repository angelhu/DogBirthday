$(document).ready(function () {
    $('#ShowNewDescriptionFormButton').on('click', function (event) {
        event.preventDefault();
        $('#DogBreedDropdown').hide();
        $('#NewDogBreedForm').show();
    });

    $('#NewDogBreedCancelButton').on('click', function (event) {
        event.preventDefault();
        $('#NewDogBreedForm').hide();
        $('#DogBreedDropdown').show();
    });

    $('#NewDogBreedOkButton').on('click', function (event) {
        event.preventDefault();
        $.post('/api/BreedsApi', {
           Description: $('#NewDogBreedDescription').val()
                   }).done(function (data) {
        console.log(data);
        $('#BreedID').append(new Option(data.Description, data.BreedID));
        $('#BreedID').val(data.BreedID);
        $('#NewDogBreedDescription').val('');

        $('#DogBreedDropdown').show();
        $('#NewDogBreedForm').hide();
    });
    });
});