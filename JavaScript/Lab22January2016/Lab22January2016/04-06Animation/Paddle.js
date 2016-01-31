var Paddle = (function(){
    function Paddle(x, y) {
        this.position = new Vector2(x, y);
        this.velocity = 20;
        this.width = 100;
        this.height = 20;
        this.movement = {left: false, right : false};
        this.image = new Image();
        this.image.src = "Paddle.png";
        this.boundingBox = new Rectangle ( x, y, this.width, this.height)
    }

    Paddle.prototype.update = function() {
        if(this.movement.right) {
            this.position.x += this.velocity;
        } else if(this.movement.left) {
            this.position.x -= this.velocity;
        }

        this.boundingBox.x = this.position.x;
        this.boundingBox.y = this.position.y;
    };

    Paddle.prototype.render = function(ctx) {
        ctx.drawImage(this.image, this.position.x, this.position.y);
    }
    return Paddle;
}());