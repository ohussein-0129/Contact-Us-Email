function validateSubject()
{
    checkIfEmpty(document.getElementById("<%= this.Subject.ClientID %>"));
}

function validateName()
{
    checkIfEmpty(document.getElementById("<%= this.Name.ClientID %>"));
}

function validateMsg() {
    checkIfEmpty(document.getElementById("<%= this.Msg.ClientID %>"));
}

function checkIfEmpty(text)
{
    if (text != '')
        args.IsValid = true;
    else
        args.IsValid = false;
}