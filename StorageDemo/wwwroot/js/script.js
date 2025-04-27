document.addEventListener("DOMContentLoaded", function () {
    // Initialize CodeMirror for Existing Users
    var existingEditor = CodeMirror.fromTextArea(document.getElementById("txtJson"), {
        mode: "application/json",
        lineNumbers: true,
        theme: "default",
        tabSize: 2,
        autoCloseBrackets: true
    });
});

function initializeCodeMirror() {
    var existingEditor = CodeMirror.fromTextArea(document.getElementById("txtJson"), {
        mode: "application/json",
        lineNumbers: true,
        theme: "default",
        tabSize: 2,
        autoCloseBrackets: true
    });
}