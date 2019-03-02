function AjaxPost(loadFrom, parameters, successFunc, errorFunc) {/*senkron*/
    $.ajax(
            {
                async:false,
                url: loadFrom,
                data: parameters,
                contentType: 'application/json',
                type:'POST',
                success: successFunc,
                error: errorFunc
            }
        )
}

function AjaxPostAsync(loadFrom, parameters, successFunc, errorFunc) {/*asenkron*/
    $.ajax(
            {
                url: loadFrom,
                data: parameters,
                contentType: 'application/json',
                type: 'POST',
                success: successFunc,
                error: errorFunc
            }
        )
}