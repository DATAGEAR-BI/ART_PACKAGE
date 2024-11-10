class CategoryTree extends HTMLElement {
    constructor() {
        super();
        this.attachShadow({ mode: "open" });

        // CSS to style the tree
        const style = `
                .tree {
                    list-style-type: none;
                    padding-left: 20px;
                }
                .tree .node {
                    padding: 5px;
                    cursor: pointer;
                    border-radius: 5px;
                }
                .tree .node.selected {
                    background-color: #007bff;
                    color: #fff;
                }
                .tree .toggle-icon {
                    font-size: 0.8rem;
                    margin-right: 5px;
                }
                .d-none {
                    display: none;
                }
            `;

        // Use `adoptedStyleSheets` if available, fallback to `<style>` otherwise
        if (this.shadowRoot.adoptedStyleSheets !== undefined) {
            const sheet = new CSSStyleSheet();
            sheet.replaceSync(style);
            this.shadowRoot.adoptedStyleSheets = [sheet];
        } else {
            const styleElement = document.createElement('style');
            styleElement.textContent = style;
            this.shadowRoot.appendChild(styleElement);
        }

        // Create container for the category tree
        const container = document.createElement('ul');
        container.classList.add('tree');
        this.shadowRoot.appendChild(container);

        this.categories = [];
        this.onCategoryChange = null;
        this.selectedCategoryId = null; // Store the selected category ID
    }

    static get observedAttributes() {
        return ['categories', 'oncategorychange'];
    }

    attributeChangedCallback(name, oldValue, newValue) {
        if (name === 'categories') {
            this.categories = JSON.parse(newValue);
            this.renderTree();
        } else if (name === 'oncategorychange') {
            this.onCategoryChange = new Function('return ' + newValue)();
        }
    }

    buildTree(categories) {
        const map = {};
        const roots = [];
        categories.forEach(cat => {
            map[cat.Id] = { ...cat, children: [] };
        });

        categories.forEach(cat => {
            if (cat.ParentId) {
                map[cat.ParentId]?.children.push(map[cat.Id]);
            } else {
                roots.push(map[cat.Id]);
            }
        });
        return roots;
    }

    renderTree() {
        const container = this.shadowRoot.querySelector('.tree');
        container.innerHTML = ''; // Clear existing nodes

        const treeData = this.buildTree(this.categories);
        this.createTreeNodes(container, treeData);

        // Collapse all nodes initially
        this.shadowRoot.querySelectorAll('.tree .tree').forEach(ul => ul.classList.add('d-none'));
    }

    createTreeNodes(container, categories) {
        categories.forEach(category => {
            const li = document.createElement('li');
            li.classList.add('node');
            li.setAttribute('data-id', category.Id);
            li.innerHTML = `
                    <span class="toggle-icon">▸</span> ${category.Name}
                `;
            li.onclick = (event) => this.handleNodeClick(event, li, category.children);

            container.appendChild(li);

            if (category.children && category.children.length > 0) {
                const childUl = document.createElement('ul');
                childUl.classList.add('tree', 'd-none', 'ml-4');
                li.appendChild(childUl);
                this.createTreeNodes(childUl, category.children);
            } else {
                li.querySelector('.toggle-icon').classList.add('invisible'); // Hide toggle for leaf nodes
            }
        });
    }

    handleNodeClick(event, node, children) {
        event.stopPropagation();

        const childTree = node.querySelector('.tree');
        if (children && children.length > 0 && childTree) {
            childTree.classList.toggle('d-none');
            const icon = node.querySelector('.toggle-icon');
            icon.textContent = icon.textContent === '▸' ? '▾' : '▸';
        }

        this.selectNode(node);
    }

    selectNode(node) {
        this.shadowRoot.querySelectorAll('.node').forEach(n => n.classList.remove('selected'));
        node.classList.add('selected');

        this.selectedCategoryId = node.getAttribute('data-id'); // Update selected category ID

        const selectedId = this.selectedCategoryId;
        const selectedCategory = this.categories.find(cat => cat.Id === selectedId);

        if (this.onCategoryChange && selectedCategory) {
            this.onCategoryChange(selectedCategory.Name, selectedCategory.id);
        }
    }

    // Getter for the selected category ID
    get selectedValue() {
        return this.selectedCategoryId;
    }
}

// Define the custom element
customElements.define('category-tree', CategoryTree);
