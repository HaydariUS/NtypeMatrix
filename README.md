# NtypeMatrix
Adding and multiplying two matrices, and printing the matrix (in a square shape).

Project task description
Implement the N matrix type which contains integers. These are square matrices that can contain nonzero entries only in their first and last column, and in their main diagonal. Don't store the zero entries. Store only the entries that can be nonzero in a sequence. Implement as methods: getting the entry located at index (i, j), adding and multiplying two matrices, and printing the matrix (in a square shape).

N type Matrix

Set of values
Diag(n) = { a ∈ ℤ n×n | ∀ i,j ∈ [1..n]: i≠j → a[i,j]=0 }

Operations
1. Getting an entry
Getting the entry i-th row and j-th column (i,j[1..n]): e:=a[i,j].
If i = j, the value is retrieved from the diagonal. if j = 0, it's from the first column. if j = n-1 it's from the last column. For all other cases, the function returns 0.

Formally: 
A : Ntype(n) × ℤ × ℤ × ℤ 
          a            I     j      e 
Pre = ( a=a’  i=i’  j=j’  i,j[1..n] ) 
Post = ( Pre  e=a[i,j] )

2. Setting an entry
Assigning a value to the i-th row and j-th column. Assignments are only allowed if i = j (diagonal), j = 0 (first column), or j = n-1 (last column). Attempting to set a value outside these constraints throws a ReferenceToNullPartException.

Formally: 
A = Ntype(n) × ℤ × ℤ × ℤ 
           a              I      j      e 
Pre = ( e=e’  a=a’  i=i’  j=j’  i,j[1..n]  i=j ) 
Post = (e=e’  i=i’  j=j’  a[i,j]=e  k,l[1..n]: (k≠i  l≠j)→ a[k,l]=a’[k,l] )

3. Sum
Computing the sum of two N-type matrices of the same size. The operation is element-wise for the first and last columns and the diagonal. All other entries remain zero.
Formally:
A = Ntype(n) × Ntype(n) × Ntype(n) 
            a                 b                    c 
Pre = ( a=a’  b=b’) 
Post = ( Pre  i,j[1..n]: c[i,j]= a[i,j] + b[i,j] )
4. Multiplication
Multiplying two N-type matrices of the same size. Due to the constraints of N-type matrices, the multiplication simplifies to element-wise multiplication for the diagonal. For the first and last columns, each element is multiplied by the corresponding diagonal element from the other matrix.

Formally:
A = Ntype(n) × Ntype(n) × Ntype(n) 
           a                  b                    c 
Pre = ( a=a’  b=b’) 
Post = ( Pre  i[1..n]: c[i,i]= a[i,i]*b[i,i] AND i,j[1..n]: i≠j → c[i,j]=0)

Representation
1st column, last column and main diagonal of (n x n) matrix has to be stored
               b1       0       d1         …  0 
               b2       a11  d2           … 0 
a =          b3       0      d3           … 0                v1 = < a11 ann > 
                0         0       0            … ann.               v2 = < b1  b2  b3 bn >
                                                                              v3 = < d1  d2  d3 dn >

Arrays (v1, v2 and v3) are needed, with the help of which any entry of the N type matrix can be get:

               { 𝑣[𝑖] 𝑖𝑓 𝑖 = 𝑗 }
𝑎[𝑖,𝑗] =   { 𝑣2[𝑖] 𝑖𝑓 𝑖 = 𝑗 }
                { 𝑣3[𝑖] 𝑖𝑓 𝑖 = 𝑗 } 
                { 0 𝑖𝑓 𝑖 ≠ 𝑗 }


Implementation

1. Getting an entry
Getting the entry of the ith column and jth row (i,j[1..n]) e:=a[i,j] where the matrix is represented by v1,v2,v3,1in, and n stands for the size of the matrix can be implemented as

2. Setting an entry
Getting the entry of the ith column and jth row (i,j[1..n]) e:=a[i,j] where the matrix is represented by v1,v2,v3,1in, and n stands for the size of the matrix can be implemented as

3. Sum

The sum of matrices a and b (represented by arrays t and u) goes to matrix c (represented by array u), where all of the arrays have to have the same size.

i[0..n-1]: u[i]:= v[i] + t[i]

3. Multiplication
The product of matrices a and b (represented by arrays t and u) goes to matrix c (represented by array u), where all of the arrays have to have the same size.

i[0..n-1]: u[i]:= v[i] * t[i]


Testing

Testing the operations (black box testing)

1. Creating, reading, and writing matrices of different sizes.
 -  Creating a matrix of size 3 and verifying its existence and size.

2. Handling creation of zero or negative-size matrices.
 -  Verifying that an exception is thrown when attempting to create a matrix with a size of 0 or less.

3. Setting values at valid indices.
 -  Setting values at various valid indices in the matrix and verifying that the values are correctly stored.

4. Handling setting values at invalid indices.
 -  Verifying that an exception is thrown when attempting to set a value at an invalid index in the matrix.

5. Getting values for non-stored indices.
 -  Verifying that accessing non-stored values returns 0.

6. Addition operation.
 -  Adding two matrices of size 3 and verifying the correctness of the addition operation by checking specific entries in the result matrix.

7. Addition operation with matrices of different sizes.
 -  Verifying that an exception is thrown when attempting to add matrices of different sizes.

8. Multiplication operation.
 -  Multiplying two matrices of size 3 and verifying the correctness of the multiplication operation by checking specific entries in the result matrix.

9. Multiplication operation with matrices of different sizes.
 -  Verifying that an exception is thrown when attempting to multiply matrices of different sizes.


Testing based on the code (white box testing)
1. Generating different size matrix (-1, 0, 1 and above)
2. Implementing and showing exceptions
