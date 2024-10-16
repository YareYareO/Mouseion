// the zindex and the page-flip of PAGES are entirely handled here. 
// Cover, backcover, and other css styles are entirely in Book.razor.css

const PageZIndexPivot = 100 / 2; 

//function Setup() {
    console.log("1")
    document.querySelectorAll('.page').forEach(page => {
        page.style.zIndex = PageZIndexPivot - page.dataset.pageNumber;
    });

    document.querySelectorAll('.bookcheckbox').forEach(checkbox => {
        checkbox.addEventListener('change', function () {
            // Access the correct data attribute
            const connectedPage = this.dataset.checkNumber; // Correct way to access data-page-number
            if (connectedPage != null) {
                // Find the corresponding page using the custom property --pagenumber
                const page = document.querySelector(`.page[data-page-number="${connectedPage}"]`);
                if (page != null) {

                    if (this.checked) {
                        // Flip the page and set a higher z-index when checked
                        page.style.transform = 'rotateY(-180deg)';
                        page.style.zIndex = PageZIndexPivot + parseInt(connectedPage); // Higher z-index to bring it to the front
                    } else {
                        // Reset the transformation and z-index when unchecked
                        page.style.transform = 'rotateY(0deg)';
                        page.style.zIndex = PageZIndexPivot - parseInt(connectedPage); // Reset to the original z-index
                    }
                }
            }
        });
    });
//}

function onThingsChanged() {
    console.log("Things have changed!");

    document.querySelectorAll(".page").forEach(page => {
        const pageId = page.dataset.pageNumber;
        page.style.transform = 'rotateY(0deg)';
        page.style.zIndex = PageZIndexPivot - parseInt(pageId);
    });
    document.querySelectorAll('.bookcheckbox').forEach(checkbox => {
        checkbox.checked = false;
    });
};