window.onload = render()

 function getColor(initials){
    const colors = [
        '#F48FB1',
        '#CE93D8',
        '#B39DDB',
        '#90CAF9',
        '#8C9EFF',
        '#A5D6A7',
        '#FFCC80',
        '#FFAB91',
      ];
      let ascii = initials.charCodeAt(0).toString()[1];
      return colors[ascii]!=undefined? colors[ascii]:colors[0]
 }
 
function render(){
    
    let area= document.getElementsByClassName('user')[0];
        let firstChar = document.getElementsByClassName("user-name")[0].textContent.charAt(0).toUpperCase();

        let articleEl = document.createElement("article");
        articleEl.classList.add('article')
       
        let initials = document.createElement('span');
        initials.classList.add('initials')
        initials.textContent = firstChar;
        initials.style.backgroundColor=getColor(initials.textContent)

        articleEl.appendChild(initials);
        area.insertBefore(articleEl,area.firstChild)
        area.appendChild(document.createElement('hr'))
 }