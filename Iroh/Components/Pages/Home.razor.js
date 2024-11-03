const draggable = document.getElementById('draggable');
let isDragging = false;
let startX, startY, currentRotation = 0;
console.log("hi");
function startDrag(event) {
    isDragging = true;
    // Capture the starting position
    startX = event.type === 'touchstart' ? event.touches[0].clientX : event.clientX;
    startY = event.type === 'touchstart' ? event.touches[0].clientY : event.clientY;
    event.preventDefault();
}

function onDrag(event) {
    if (!isDragging) return;

    // Get current position
    const currentX = event.type === 'touchmove' ? event.touches[0].clientX : event.clientX;
    const currentY = event.type === 'touchmove' ? event.touches[0].clientY : event.clientY;

    // Calculate the angle of rotation based on the drag distance
    const deltaX = currentX - startX;
    const deltaY = currentY - startY;
    const angleChange = deltaX + deltaY;

    // Increment the current rotation based on the calculated change
    currentRotation += angleChange * 0.2; // Adjust multiplier for sensitivity
    draggable.style.transform = `rotate(${currentRotation}deg)`;

    // Update start positions for smooth rotation
    startX = currentX;
    startY = currentY;
}

function endDrag() {
    isDragging = false;
}

// Event listeners for mouse and touch
draggable.addEventListener('mousedown', startDrag);
draggable.addEventListener('mousemove', onDrag);
draggable.addEventListener('mouseup', endDrag);
draggable.addEventListener('mouseleave', endDrag);

draggable.addEventListener('touchstart', startDrag);
draggable.addEventListener('touchmove', onDrag);
draggable.addEventListener('touchend', endDrag);
draggable.addEventListener('touchcancel', endDrag);