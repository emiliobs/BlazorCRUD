function saveAsFile(fileName, bytesBase64) {

    var link = document.createElement('a');
    link.download = fileName;
    link.href = "data:application/actect-stream;base64," + bytesBase64;
    document.body.appendChild(link);
    link.click();
    document.body.removeChild(link);

}