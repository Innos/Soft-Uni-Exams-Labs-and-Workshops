var canvas = document.getElementById('canvas');
var ctx = canvas.getContext('2d');

var input = new Input();
attachListeners(input);

var paddle = new Paddle(canvas.width/2, canvas.height - 50);
var ball = new Ball(canvas.width/2, canvas.height - paddle.height - 50);

var previousTime = Date.now();
var ballCollision = false;

function update() {
    this.tick();
    this.render(ctx);
    requestAnimationFrame(update);
}

function tick() {
    movePlayer();
    modifyBall();
    collision();

    paddle.update();
    ball.update();
}

function render(ctx) {
    ctx.clearRect(0, 0, canvas.width, canvas.height);
    paddle.render(ctx);
    ball.render(ctx);
}

function movePlayer() {
    paddle.movement.right = !!input.right;
    paddle.movement.left = !!input.left;
}

function modifyBall() {
    var now = Date.now();
    var difference = Math.abs(now - previousTime) / 1000;
    if(difference >= 10) {
        previousTime = now;
        ball.velocityX += 0.5;
        if(ball.velocityY < 0)
        {
            ball.velocityY -= 0.5;
        }
        else{
            ball.velocityY += 0.5;
        }

    }
}

function collision(){
    if(ball.boundingBox.intersects(paddle.boundingBox)){
        ball.velocityY = -ball.velocityY;
    }
    if(ball.position.x <= 0 || (ball.position.x + ball.width)>= canvas.width)
    {
        ball.velocityX = -ball.velocityX;
    }
    if(ball.position.y <= 0 || (ball.position.y + ball.height)>= canvas.height)
    {
        ball.velocityY = -ball.velocityY;
    }
    if(paddle.position.x <= 0)
    {
        paddle.movement.left = false;
    }
    if(paddle.position.x+ paddle.width >= canvas.width)
    {
        paddle.movement.right = false;
    }
}

update();