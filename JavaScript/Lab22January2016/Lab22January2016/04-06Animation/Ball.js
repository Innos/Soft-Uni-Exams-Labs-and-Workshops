var Ball = (function(){
    function Ball(x, y) {
        this.position = new Vector2(x, y);
        this.velocityX = 3;
        this.velocityY = -3;
        this.width = 20;
        this.height = 20;
        this.movement = {left: false, right : false};
        this.image = new Image();
        this.image.src = "ball.png";
        this.boundingBox = new Rectangle ( x, y, this.width, this.height)
    }

    Ball.prototype.update = function() {

        this.position.x += this.velocityX;
        this.position.y += this.velocityY;

        this.boundingBox.x = this.position.x;
        this.boundingBox.y = this.position.y;

    };

    Ball.prototype.render = function(ctx) {
        ctx.drawImage(this.image,this.position.x,this.position.y);
    };

    return Ball;
}());
