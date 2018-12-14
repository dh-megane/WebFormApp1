const C_TITLE = "ダイアログ";
const C_OK_BTN_MSG = "OK";
const C_NG_BTN_MSG = "キャンセル";

function showSubWindow(url) {

    $('#ifr').attr('src', url);
    $('#ifr').load(function () {

        var contentDocument = this.contentDocument || this.contentWindow.document;
        $(this).width = contentDocument.documentElement.scrollWidth;
        $(this).hight = contentDocument.documentElement.scrollHight;
    });

    $('#subWindow').dialog({
        modal: true, //モーダル表示
        title: C_TITLE,
        width: 'auto',
        hight: 'auto'
    });
}