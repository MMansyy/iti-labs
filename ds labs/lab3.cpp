#include <iostream>
using namespace std;

struct node
{
    int data;
    node *left;
    node *right;
};

class BST
{
    node *root;

    node *insertRec(node *root, int x)
    {
        if (root == nullptr)
        {
            node *newNode = new node();
            newNode->data = x;
            newNode->left = newNode->right = nullptr;
            return newNode;
        }
        if (x < root->data)
        {
            root->left = insertRec(root->left, x);
        }
        else if (x > root->data)
        {
            root->right = insertRec(root->right, x);
        }
        return root;
    }

    void inorderRec(node *root)
    {
        if (root != nullptr)
        {
            inorderRec(root->left);
            cout << root->data << " ";
            inorderRec(root->right);
        }
    }

    void preorderRec(node *root)
    {
        if (root != nullptr)
        {
            cout << root->data << " ";
            preorderRec(root->left);
            preorderRec(root->right);
        }
    }

    void postorderRec(node *root)
    {
        if (root != nullptr)
        {
            postorderRec(root->left);
            postorderRec(root->right);
            cout << root->data << " ";
        }
    }

public:
    BST()
    {
        root = nullptr;
    }
    void insert(int x)
    {
        root = insertRec(root, x);
    }
    void inorder()
    {
        inorderRec(root);
    }
    void preorder()
    {
        preorderRec(root);
    }
    void postorder()
    {
        postorderRec(root);
    }
};

int main()
{
    BST tree;
    tree.insert(50);
    tree.insert(30);
    tree.insert(20);
    tree.insert(40);
    tree.insert(70);
    tree.insert(60);
    tree.insert(80);

    cout << "Inorder traversal: ";
    tree.inorder();
    cout << endl;

    cout << "Preorder traversal: ";
    tree.preorder();
    cout << endl;

    cout << "Postorder traversal: ";
    tree.postorder();
    cout << endl;

    return 0;
}
