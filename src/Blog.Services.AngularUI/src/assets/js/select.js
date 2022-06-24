function newEl(tag, attrs) {
  let e = document.createElement(tag);
  if (attrs !== undefined) Object.keys(attrs).forEach(k => {
    if (k === 'class') {
      Array.isArray(attrs[k])
        ? attrs[k].forEach(o => o !== '' ? e.classList.add(o) : 0)
        : (attrs[k] !== '' ? e.classList.add(attrs[k]) : 0);
    } else if (k === 'style') {
      Object.keys(attrs[k]).forEach(ks => {
        e.style[ks] = attrs[k][ks];
      });
    } else if (k === 'text') {
      attrs[k] === '' ? e.innerHTML = '&nbsp;' : e.innerText = attrs[k];
    } else e[k] = attrs[k];
  });
  return e;
}

// this function is for add select option
function addSelectList(select, selectDropdown, itemValue, itemText) {
  // create new option for select
  let opt = document.createElement('option');
  opt.value = itemValue;
  opt.innerHTML = itemText;
  select.appendChild(opt);
  // create new option for select dropDown
  let op = newEl('div', {
    optEl: opt
  });
  op.appendChild(newEl('label', {
    text: opt.text
  }));
  op.addEventListener('click', function () {
    op.optEl.selected = !!!op.optEl.selected;
    select.dispatchEvent(new Event('change'));
  });
  selectDropdown.appendChild(op);
}

// refresh dropdown
function selectRefresh(select, dropDown) {
  let optext = dropDown.querySelector('span.optext');
  dropDown.removeChild(optext);
  let sel = select.selectedOptions[0];
  let c = newEl('span', {
    "class": 'optext',
    text: sel.text
  });
  dropDown.appendChild(c);
}

function updateSelectDropdown(selectId, values) {

  let select = document.getElementById(selectId);
  // dropDown
  let selectDropDown = document.getElementById(selectId + '-select');
  // dropDown Options
  let selectDropDownList = selectDropDown.querySelector('.select-dropdown-list');
  if (values.length > 0) {
    // make empty the select
    select.querySelectorAll('*').forEach(function (n) {
      return n.remove();
    });
    selectDropDownList.querySelectorAll('*').forEach(function (n) {
      return n.remove();
    });
    values.forEach(function (element) {
      addSelectList(select, selectDropDownList, element.value, element.name);
    });
    selectRefresh(select, selectDropDown);
  }
}

function multiSelectDropdown() {

  document.querySelectorAll("select[multiple]").forEach((el, k) => {

    var div = newEl('div', {
      class: 'multiselect-dropdown'
    });

    if (el.hasAttribute('isDone')) {
      return;
    }

    if (!el.hasAttribute('set')) {
      return;
    }

    // add id to div while select had id
    if (el.hasAttribute('id')) {
      div.setAttribute('id', el.attributes['id'].value + '_select');
    }


    // add attr to select that select is done
    el.setAttribute('isDone', '');

    el.style.display = 'none';
    el.parentNode.insertBefore(div, el.nextSibling);
    var listWrap = newEl('div', {
      class: 'multiselect-dropdown-list-wrapper'
    });
    var list = newEl('div', {
      class: 'multiselect-dropdown-list'
    });
    var search = newEl('input', {
      class: ['multiselect-dropdown-search'],
      placeholder: 'جستجو'
    });


    // search attr
    if (el.hasAttribute('search')) {
      search.style.display = el.attributes['search'].value === 'true' ? 'block' : 'none';
    }


    listWrap.appendChild(search);
    div.appendChild(listWrap);
    listWrap.appendChild(list);

    el.loadOptions = () => {
      list.innerHTML = '';

      if (el.hasAttribute('select-all')) {
        if (el.attributes['select-all'].value == 'true') {
          selectAllBox();
        }
      } else {
        selectAllBox();
      }

      function selectAllBox() {
        var op = newEl('div',
          {
            class: 'multiselect-dropdown-all-selector'
          });
        var ic = newEl('input', {
          type: 'checkbox'
        });
        op.appendChild(ic);
        op.appendChild(newEl('label', {
          text: "انتخاب همه"
        }));

        op.addEventListener('click', () => {
          op.querySelector("input").checked = !op.querySelector("input").checked;

          var ch = op.querySelector("input").checked;
          list.querySelectorAll("input").forEach(i => i.checked = ch);

          Array.from(el.options).map(x => x.selected = ch);

          el.dispatchEvent(new Event('change'));
        });
        ic.addEventListener('click', (ev) => {
          ic.checked = !ic.checked;
        });

        list.appendChild(op);
      }


      Array.from(el.options).map(o => {
        var op = newEl('div', {
          class: o.selected ? 'checked' : '',
          optEl: o
        })
        var ic = newEl('input', {
          type: 'checkbox',
          checked: o.selected
        });
        op.appendChild(ic);
        op.appendChild(newEl('label', {
          text: o.text
        }));

        op.addEventListener('click', () => {
          op.querySelector("input").checked = !op.querySelector("input").checked;
          op.optEl.selected = !!!op.optEl.selected;
          el.dispatchEvent(new Event('change'));
        });
        ic.addEventListener('click', (ev) => {
          ic.checked = !ic.checked;
        });

        list.appendChild(op);
      });
      div.listEl = listWrap;

      div.refresh = () => {
        div.querySelectorAll('span.optext, span.placeholder').forEach(t => div.removeChild(t));

        var sels = Array.from(el.selectedOptions);
        if (sels.length > 3) {
          div.appendChild(newEl('span', {
            class: ['optext', 'maxselected'],
            text: sels.length + ' ' + 'انتخاب شده'
          }));
        } else {
          sels.map(x => {
            var c = newEl('span', {
              class: 'optext',
              text: x.text
            });
            div.appendChild(c);
          });
        }

        var placeholder = "انتخاب کنید";

        if (el.hasAttribute('placeholder')) {
          placeholder = el.attributes['placeholder'].value;
        }


        if (0 === el.selectedOptions.length) {
          div.appendChild(newEl('span', {
            class: 'placeholder',
            text: placeholder
          }));
        }


      };
      div.refresh();
    }
    el.loadOptions();

    search.addEventListener('input', () => {
      list.querySelectorAll("div").forEach(d => {
        var txt = d.querySelector("label").innerText.toUpperCase();
        d.style.display = txt.includes(search.value.toUpperCase()) ? 'block' : 'none';
      });


      var filteredItem = list.querySelectorAll('div[style="display: block;"]');


      var notFound = list.querySelector("h3");

      if (filteredItem.length == 0) {
        if (notFound == null) {
          list.appendChild(newEl('h3', {
            class: 'not-found',
            text: 'نتیجه ای یافت نشد'
          }));
        }
      } else {
        if (notFound != null) {
          list.removeChild(notFound);
        }
      }
    });

    div.addEventListener('click', () => {
      div.listEl.style.display = 'block';
      search.focus();
      search.select();
    });

    document.addEventListener('click', function (event) {
      if (!div.contains(event.target)) {
        listWrap.style.display = 'none';
        div.refresh();
      }
    });
  });
}
