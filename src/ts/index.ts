function initAppFiles() {
  const folders = document.querySelectorAll('[data-folder-id]');

  folders.forEach((folder) => {
    folder.addEventListener('click', () => {
      const f = folder as HTMLAnchorElement;
      const url = new URL(f.href);
      window.location.hash = url.hash;
    });
  });
  
  let currentUrlHash = new URL(window.location.href).hash;
  
  // if(currentUrlHash) {
  //   let hash = currentUrlHash.replace("#","");
  
  //   var hashFolder = document.getElementById(hash);
  //   openCollapse(hashFolder)
  // }
  
  // function openCollapse(elem: HTMLElement) {
  
  //   var bsCollapse = new (bootstrap as any).Collapse(elem);
  
  //   // bsCollapse.show();
  
  //   let parentCollapse = elem.closest('.collapse') as HTMLElement;
  //   if(parentCollapse) {
  //     openCollapse(parentCollapse);
  //   }
  // }

  if(currentUrlHash) {
    var hashFolder = document.querySelector(`a[href='${currentUrlHash}']`);
    if(hashFolder != null)
      openCollapse(hashFolder)
  }
  
  function openCollapse(elem: Element) {
    (elem as HTMLElement).click();
  
    let parentCollapse = elem.parentElement.previousElementSibling;
    if(parentCollapse && parentCollapse.classList.contains('folder')) {
      openCollapse(parentCollapse);
    }
  }  
}

// so it can be called from the HTML when content re-initializes dynamically
const winAny = (window as any);
winAny.appFiles ??= {};
winAny.appFiles.init ??= initAppFiles;

