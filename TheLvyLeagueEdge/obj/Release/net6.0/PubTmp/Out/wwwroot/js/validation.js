$("#fullname").keypress(function (e) {
    
    let char = String.fromCharCode(e.keyCode);
    if (/^[A-Za-z ]+$/.test(char)) return true;
    else e.preventDefault();
    return;
})
$("#mobilenumber").keypress(function (e) {
    
    var k;
    k = e.charCode || e.keyCode;
    this.maxLength = 10;
    if (e.which == 32) {
        e.preventDefault();
    }
    return (k == 8 || (k >= 48 && k <= 57))
})
$("#fullname").focusout(function (e) {
    if (e.target.value == '')
    {
        e.currentTarget.append('<div><small style="color:red;">Enter FullName</small></div >');
        //var element = document.getElementById('fullname').innerHTML;
        //element = '<div><small style="color:red;">Enter FullName</small></div >';
        //let x = '<div>' +
        //    '<small style="color:red;">Enter FullName</small>' +
        //    '</div >';
        //e.innerHTML = "";
        //e.innerHTML += x;
    }
})
function Loader(e)
{
    
    if (e == 1) {
        
    }
    else {

    }
    
}