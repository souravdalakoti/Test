function loader(e)
{
    if (e == 1) {
       return $("#loader").css('display', 'block');
    }
    else {
        return $("#loader").css('display', 'none');
    }
}

