function binarySearchCart(sortedArray, key){
    let start = 0;
    let end = sortedArray.length - 1;
    while (start <= end) {
        let middle = Math.floor((start + end) / 2);

        if (parseInt(sortedArray[middle]["bookId"]) === key) {
            return middle;
        } else if (parseInt(sortedArray[middle]["bookId"]) < key) {
            start = middle + 1;
        } else {
            end = middle - 1;
        }
    }
    return -1;
}
function sortArrayCart(array)
{
    let i, j, t;
    for(i=0; i<array.length; i++)
    {
        for(j=i; j>0; j--)
        {
            if(parseInt(array[j-1]["bookId"]) > parseInt(array[j]["bookId"]))
            {
                t = array[j-1];
                array[j-1] = array[j];
                array[j] = t;
            }
        }
    }
    return array;

}