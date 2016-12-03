#pragma strict

var canvas: Canvas;

function Start () {
    canvas.enabled = false;
}

function OnTriggerEnter (info : Collider) {
    if (info.tag == "Player") {
        canvas.enabled = true;
    }
}

function OnTriggerExit (info : Collider) {
    if (info.tag == "Player") {
        canvas.enabled = false;
    }
}