using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using CodeLibrary;

namespace GraphTest
{
    [TestClass]
    public class NodeTest
    {
        /// <summary>A test for the constructor</summary>
        /// <remarks>
        /// Test: Construct with name only
        /// Expected: Normal object
        /// </remarks>
        [TestMethod]
        public void ConstructorTest_NameNoSubNode_Success()
        {
            // Setup
            var name = "Root";

            // Expected Values
            var expectedObjectType = typeof(Node);

            // Actual Test
            var node = new Node(name);

            // Verification
            Assert.AreEqual<Type>(expectedObjectType, node.GetType(), "Wrong type constructed");
        }

        /// <summary>A test for the constructor</summary>
        /// <remarks>
        /// Test: Construct with name only; name has space
        /// Expected: Normal object
        /// </remarks>
        [TestMethod]
        public void ConstructorTest_NameHasSpace_Success()
        {
            // Setup
            var name = "Root Node";

            // Expected Values
            var expectedObjectType = typeof(Node);

            // Actual Test
            var node = new Node(name);

            // Verification
            Assert.AreEqual<Type>(expectedObjectType, node.GetType(), "Wrong type constructed");
        }

        /// <summary>A test for the constructor</summary>
        /// <remarks>
        /// Test: Construct with name only; name has punctuation
        /// Expected: Normal object
        /// </remarks>
        [TestMethod]
        public void ConstructorTest_NameHasPunctuation_Success()
        {
            // Setup
            var name = "Root Node!";

            // Expected Values
            var expectedObjectType = typeof(Node);

            // Actual Test
            var node = new Node(name);

            // Verification
            Assert.AreEqual<Type>(expectedObjectType, node.GetType(), "Wrong type constructed");
        }

        /// <summary>A test for the constructor</summary>
        /// <remarks>
        /// Test: Construct with name only; name has non-printable character
        /// Expected: Normal object
        /// </remarks>
        [TestMethod]
        public void ConstructorTest_NameHasNonPrintable_Success()
        {
            // Setup
            var name = "Root Node\01";

            // Expected Values
            var expectedObjectType = typeof(Node);

            // Actual Test
            var node = new Node(name);

            // Verification
            Assert.AreEqual<Type>(expectedObjectType, node.GetType(), "Wrong type constructed");
        }

        /// <summary>A test for the constructor</summary>
        /// <remarks>
        /// Test: Construct with name and one sub-node
        /// Expected: Normal object
        /// </remarks>
        [TestMethod]
        public void ConstructorTest_NameOneSubNode_Success()
        {
            // Setup
            var name = "Root Node";
            var subNode1 = new Node("Sub-Node");

            // Expected Values
            var expectedObjectType = typeof(Node);

            // Actual Test
            var node = new Node(name);

            // Verification
            Assert.AreEqual<Type>(node.GetType(), expectedObjectType, "Wrong type constructed");
        }
        /// <summary>A test for the constructor</summary>
        /// <remarks>
        /// Test: Construct with null name
        /// Expected: Exception ArgumentNullException
        /// </remarks>
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException), "Didn't detect null name")]
        public void ConstructorTest_NullName_Exception()
        {
            // Setup
            string name = null;

            // No Expected Values (should throw exception)

            // Actual Test
            var node = new Node(name);

            // No Verification (ExpectedException should take care of it)
        }

        /// <summary>A test for the constructor</summary>
        /// <remarks>
        /// Test: Construct with empty name
        /// Expected: Exception ArgumentException
        /// </remarks>
        [TestMethod]
        [ExpectedException(typeof(ArgumentException), "Didn't detect empty name")]
        public void ConstructorTest_EmptyName_Exception()
        {
            // Setup
            var name = string.Empty;

            // No Expected Values (should throw exception)

            // Actual Test
            var node = new Node(name);

            // No Verification (ExpectedException should take care of it)
        }

        /// <summary>A test for the constructor</summary>
        /// <remarks>
        /// Test: Construct with one null sub-node
        /// </remarks>
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException), "Didn't detect null sub-node")]
        public void ConstructorTest_NullSubNode_Exception()
        {
            // Setup
            var name = "Root Node";
            Node subNode = null;

            // No Expected Values (should throw exception)

            // Actual Test
            var node = new Node(name, subNode);

            // No Verification (ExpectedException should take care of it)
        }

        /// <summary>A test for the constructor</summary>
        /// <remarks>
        /// Test: Construct with null first sub-node
        /// Expected: Exception ArgumentException
        /// </remarks>
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException), "Didn't detect null sub-node")]
        public void ConstructorTest_NullFirstSubNode_Exception()
        {
            // Setup
            var name = "Root Node";
            Node subNode1 = null;
            var subNode2 = new Node("Sub-Node 2");

            // No Expected Values (should throw exception)

            // Actual Test
            var node = new Node(name, subNode1, subNode2);

            // No Verification (ExpectedException should take care of it)
        }

        /// <summary>A test for the constructor</summary>
        /// <remarks>
        /// Test: Construct with null second sub-node
        /// Expected: Exception ArgumentException
        /// </remarks>
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException), "Didn't detect null sub-node")]
        public void ConstructorTest_NullSecondSubNode_Exception()
        {
            // Setup
            var name = "Root Node";
            var subNode1 = new Node("Sub-Node 1");
            Node subNode2 = null;

            // No Expected Values (should throw exception)

            // Actual Test
            var node = new Node(name, subNode1, subNode2);

            // No Verification (ExpectedException should take care of it)
        }

        /// <summary>A test for Name</summary>
        /// <remarks>
        /// Test: Property Name
        /// Expected: Name set in the constructor
        /// </remarks>
        [TestMethod]
        public void NameTest_Normal_GoodResult()
        {
            // Setup
            var name = "NodeName";

            // Expected Values
            var expectedName = name;

            // Actual Test
            var node = new Node(name);

            // Verification
            Assert.AreEqual<string>(expectedName, name, "Property Name returned wrong value");
        }

        /// <summary>A test for NodesCount</summary>
        /// <remarks>
        /// Test: Property NodesCount when there are no sub-nodes
        /// Expected: 0
        /// </remarks>
        [TestMethod]
        public void NodesCountTest_NoSubNodes_GoodResult()
        {
            // Setup
            var name = "NodeName";
            var node = new Node(name);

            // Expected Values
            int expectedNodeCount = 0;

            // Actual Test
            int actualNodeCount = node.NodesCount;

            // Verification
            Assert.AreEqual<int>(expectedNodeCount, actualNodeCount, "Wrong count for no sub-nodes");
        }

        /// <summary>A test for NodesCount</summary>
        /// <remarks>
        /// Test: Property NodesCount when there is one sub-node
        /// Expected: 1
        /// </remarks>
        [TestMethod]
        public void NodesCountTest_OneSubNodes_GoodResult()
        {
            // Setup
            var name = "NodeName";
            var subNode1 = new Node("Sub-Node 1");
            var node = new Node(name, subNode1);

            // Expected Values
            int expectedNodeCount = 1;

            // Actual Test
            int actualNodeCount = node.NodesCount;

            // Verification
            Assert.AreEqual<int>(expectedNodeCount, actualNodeCount, "Wrong count for one sub-nodes");
        }

        /// <summary>A test for NodesCount</summary>
        /// <remarks>
        /// Test: Property NodesCount when there are 3 distinct sub-nodes
        /// Expected: 3
        /// </remarks>
        [TestMethod]
        public void NodesCountTest_ThreeSubNodes_GoodResult()
        {
            // Setup
            var name = "NodeName";
            var subNode1 = new Node("Sub-Node 1");
            var subNode2 = new Node("Sub-Node 2");
            var subNode3 = new Node("Sub-Node 3");
            var node = new Node(name, subNode1, subNode2, subNode3);

            // Expected Values
            int expectedNodeCount = 3;

            // Actual Test
            int actualNodeCount = node.NodesCount;

            // Verification
            Assert.AreEqual<int>(expectedNodeCount, actualNodeCount, "Wrong count for no sub-nodes");
        }

        /// <summary>A test for the method Add</summary>
        /// <remarks>
        /// Test: Adding a single null sub-node
        /// Expected: Exception ArgumentNullException
        /// </remarks>
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException), "Didn't detect null sub-node")]
        public void AddTest_NullSubNode_Exception()
        {
            // Setup
            var name = "Root Node";
            var node = new Node(name);
            Node subNode = null;

            // No Expected Values (should throw exception)

            // Actual Test
            node.Add(subNode);

            // No Verification (ExpectedException should take care of it)
        }

        /// <summary>A test for the method Add</summary>
        /// <remarks>
        /// Test: Adding multiple sub-nodes; first sub-node is null
        /// Expected: Exception ArgumentNullException
        /// </remarks>
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException), "Didn't detect null sub-node")]
        public void AddTest_NullFirstSubNode_Exception()
        {
            // Setup
            var name = "Root Node";
            var node = new Node(name);
            Node subNode1 = null;
            var subNode2 = new Node("Sub-Node 2");

            // No Expected Values (should throw exception)

            // Actual Test
            node.Add(subNode1, subNode2);

            // No Verification (ExpectedException should take care of it)
        }

        /// <summary>A test for the method Add</summary>
        /// <remarks>
        /// Test: Adding multiple sub-nodes; second sub-node is null
        /// Expected: Exception ArgumentNullException
        /// </remarks>
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException), "Didn't detect null sub-node")]
        public void AddTest_NullSecondSubNode_Exception()
        {
            // Setup
            var name = "Root Node";
            var node = new Node(name);
            var subNode1 = new Node("Sub-Node 1");
            Node subNode2 = null;

            // No Expected Values (should throw exception)

            // Actual Test
            node.Add(subNode1, subNode2);

            // No Verification (ExpectedException should take care of it)
        }

        /// <summary>A test for Add</summary>
        /// <remarks>
        /// Test: Add same a single sub-node twice
        /// Expected: Node is added only once
        /// </remarks>
        [TestMethod]
        public void AddTest_RepeatedSingleNode_GoodResultNoRepetition()
        {
            // Setup
            var name = "Root Node";
            var node = new Node(name);
            var subNode1 = new Node("Sub-Node 1");

            // Expected Values
            int expectedNodeCount = 1;

            // Actual Test
            node.Add(subNode1);
            node.Add(subNode1);

            // Verification
            Assert.IsNotNull(node[subNode1.Name], "Sub-node one not added");
            Assert.AreEqual<Node>(subNode1, node[subNode1.Name], "Node added was unexpected");
            Assert.AreEqual<int>(expectedNodeCount, node.NodesCount, "Sub-node added more than once");
        }

        /// <summary>A test for Add</summary>
        /// <remarks>
        /// Test: Add same a multiple sub-nodes, one of them twice
        /// Expected: Node is added only once
        /// </remarks>
        [TestMethod]
        public void AddTest_MultipleNodesOneIsRepeated_GoodResultNoRepetition()
        {
            // Setup
            var name = "Root Node";
            var node = new Node(name);
            var subNode1 = new Node("Sub-Node 1");
            var subNode2 = new Node("Sub-Node 2");
            var subNode3 = new Node("Sub-Node 3");

            // Expected Values
            int expectedNodeCount = 3;

            // Actual Test
            node.Add(subNode1);
            node.Add(subNode2);
            node.Add(subNode3);
            node.Add(subNode1);

            // Verification
            Assert.IsNotNull(node[subNode1.Name], "Sub-node one not added");
            Assert.AreEqual<Node>(subNode1, node[subNode1.Name], "Node added was unexpected");
            Assert.AreEqual<int>(expectedNodeCount, node.NodesCount, "Sub-node added more than once");
        }

        /// <summary>A test for Remove</summary>
        /// <remarks>
        /// Test: Empty list of nodes to remove
        /// Expected: Nothing is removed, but returns true
        /// </remarks>
        [TestMethod]
        public void RemoveTest_EmptyList_True()
        {
            // Setup
            var name = "Root Node";
            var node = new Node(name,
                            new Node("Sub-Node 1"),
                            new Node("Sub-Node 2"),
                            new Node("Sub-Node 3"));

            // Expected Values
            int expectedNodeCount = 3;

            // Actual Test
            bool result = node.Remove();

            // Verification
            Assert.IsTrue(result, "Did not return true for Remove-ing an empty list");
            Assert.AreEqual<int>(expectedNodeCount, node.NodesCount, "Unexpected node count after Remove-ing an empty list");
        }

        /// <summary>A test for Remove</summary>
        /// <remarks>
        /// Test: Remove a single sub-node (the first added)
        /// Expected: Sub-ode is removed, returns true
        /// Note: The first sub-node added is not necessarily the first in the list; node positions
        /// are implementation dependent and irrelevant.
        /// </remarks>
        [TestMethod]
        public void RemoveTest_FirstNode_True()
        {
            // Setup
            var name = "Root Node";
            var subNode1 = new Node("Sub-Node 1");
            var node = new Node(name,
                            subNode1,
                            new Node("Sub-Node 2"),
                            new Node("Sub-Node 3"));

            // Expected Values
            int expectedNodeCount = 2;

            // Actual Test
            bool result = node.Remove(subNode1.Name);

            // Verification
            Assert.IsTrue(result, "Did not return true for Remove-ing the first sub-node");
            Assert.IsNull(node[subNode1.Name], "Did not Remove the first sub-node");
            Assert.AreEqual<int>(expectedNodeCount, node.NodesCount, "Unexpected number of nodes after Remove-ing the first node");
        }

        /// <summary>A test for Remove</summary>
        /// <remarks>
        /// Test: Remove a single sub-node (NOT the first added)
        /// Expected: Sub-node is removed, returns true
        /// Note: The first sub-node added is not necessarily the first in the list; sub-node
        /// positions are implementation dependent and irrelevant.
        /// </remarks>
        [TestMethod]
        public void RemoveTest_NodeOtherThanFirst_True()
        {
            // Setup
            var name = "Root Node";
            var subNode2 = new Node("Sub-Node 2");
            var node = new Node(name,
                            new Node("Sub-Node 1"),
                            subNode2,
                            new Node("Sub-Node 3"));

            // Expected Values
            int expectedNodeCount = 2;

            // Actual Test
            bool result = node.Remove(subNode2.Name);

            // Verification
            Assert.IsTrue(result, "Did not return true for Remove-ing a sub-node");
            Assert.IsNull(node[subNode2.Name], "Did not Remove the requested sub-node");
            Assert.AreEqual<int>(expectedNodeCount, node.NodesCount, "Unexpected number of nodes after Remove-ing a non-first node");
        }

        /// <summary>A test for Remove</summary>
        /// <remarks>
        /// Test: Remove multiple sub-nodes, but not all
        /// Expected: Sub-nodes specified are removed, returns true
        /// </remarks>
        [TestMethod]
        public void RemoveTest_MultipleNodesButNotAll_True()
        {
            // Setup
            var name = "Root Node";
            var subNode1 = new Node("Sub-Node 1");
            var subNode2 = new Node("Sub-Node 2");
            var node = new Node(name,
                            subNode1,
                            subNode2,
                            new Node("Sub-Node 3"));

            // Expected Values
            int expectedNodeCount = 1;

            // Actual Test
            bool result = node.Remove(subNode1.Name, subNode2.Name);

            // Verification
            Assert.IsTrue(result, "Did not return true for Remove-ing multiple sub-nodes");
            Assert.IsNull(node[subNode1.Name], "Did not Remove the requested sub-node");
            Assert.IsNull(node[subNode2.Name], "Did not Remove the requested sub-node");
            Assert.AreEqual<int>(expectedNodeCount, node.NodesCount, "Unexpected number of nodes after Remove-ing multiple nodes");
        }

        /// <summary>A test for Remove</summary>
        /// <remarks>
        /// Test: Remove all sub-nodes
        /// Expected: All sub-nodes are removed, returns true
        /// </remarks>
        [TestMethod]
        public void RemoveTest_AllNodes_True()
        {
            // Setup
            var name = "Root Node";
            var subNode1 = new Node("Sub-Node 1");
            var subNode2 = new Node("Sub-Node 2");
            var subNode3 = new Node("Sub-Node 3");
            var node = new Node(name,
                            subNode1,
                            subNode2,
                            subNode3);

            // Expected Values
            int expectedNodeCount = 0;

            // Actual Test
            bool result = node.Remove(subNode1.Name, subNode2.Name, subNode3.Name);

            // Verification
            Assert.IsTrue(result, "Did not return true for Remove-ing all sub-nodes");
            Assert.IsNull(node[subNode1.Name], "Did not Remove the requested sub-node");
            Assert.IsNull(node[subNode2.Name], "Did not Remove the requested sub-node");
            Assert.IsNull(node[subNode3.Name], "Did not Remove the requested sub-node");
            Assert.AreEqual<int>(expectedNodeCount, node.NodesCount, "Unexpected number of nodes after Remove-ing all sub-nodes");
        }

        /// <summary>A test for Remove</summary>
        /// <remarks>
        /// Test: Remove a sub-node in a node that doesn't have any
        /// Expected: Returns false
        /// </remarks>
        [TestMethod]
        public void RemoveTest_OneSubNodeInEmptyNode_True()
        {
            // Setup
            var name = "Root Node";
            var node = new Node(name);

            // Expected Values
            int expectedNodeCount = 0;

            // Actual Test
            bool result = node.Remove("Inexistent Sub-node");

            // Verification
            Assert.IsFalse(result, "Did not return false for Remove-ing sub-nodes from empty node");
            Assert.AreEqual<int>(expectedNodeCount, node.NodesCount, "Unexpected number of nodes after Remove-ing a sub-node from empty node");
        }

        /// <summary>A test for Remove</summary>
        /// <remarks>
        /// Test: Remove a non-existent sub-node in a node that only has one sub-node
        /// Expected: Returns false
        /// </remarks>
        [TestMethod]
        public void RemoveTest_OneNonExistentSubNodeInNodeWithOneSubNode_True()
        {
            // Setup
            var name = "Root Node";
            var node = new Node(name,
                            new Node("Sub-Node 1"));

            // Expected Values
            int expectedNodeCount = 1;

            // Actual Test
            bool result = node.Remove("Inexistent Sub-node");

            // Verification
            Assert.IsFalse(result, "Did not return false for Remove-ing non-existent sub-node from node");
            Assert.AreEqual<int>(expectedNodeCount, node.NodesCount, "Unexpected number of nodes after Remove-ing a non-existent sub-node from node");
        }

        /// <summary>A test for Remove</summary>
        /// <remarks>
        /// Test: Remove a non-existent sub-node in a node that has multiple sub-nodes
        /// Expected: Returns false
        /// </remarks>
        [TestMethod]
        public void RemoveTest_OneNonExistentSubNodeInNodeWithMultipleSubNodes_True()
        {
            // Setup
            var name = "Root Node";
            var node = new Node(name,
                            new Node("Sub-Node 1"),
                            new Node("Sub-Node 2"),
                            new Node("Sub-Node 3"));

            // Expected Values
            int expectedNodeCount = 3;

            // Actual Test
            bool result = node.Remove("Inexistent Sub-node");

            // Verification
            Assert.IsFalse(result, "Did not return false for Remove-ing non-existent sub-node from node");
            Assert.AreEqual<int>(expectedNodeCount, node.NodesCount, "Unexpected number of nodes after Remove-ing a non-existent sub-node from node");
        }

        /// <summary>A test for Remove</summary>
        /// <remarks>
        /// Test: Remove multiple non-existent sub-node in a node that has multiple sub-nodes
        /// Expected: Returns false
        /// </remarks>
        [TestMethod]
        public void RemoveTest_MultipleNonExistentSubNodeInNodeWithMultipleSubNodes_True()
        {
            // Setup
            var name = "Root Node";
            var node = new Node(name,
                            new Node("Sub-Node 1"),
                            new Node("Sub-Node 2"),
                            new Node("Sub-Node 3"));

            // Expected Values
            int expectedNodeCount = 3;

            // Actual Test
            bool result = node.Remove("Inexistent Sub-node", "Another node");

            // Verification
            Assert.IsFalse(result, "Did not return false for Remove-ing non-existent sub-nodes from node");
            Assert.AreEqual<int>(expectedNodeCount, node.NodesCount, "Unexpected number of nodes after Remove-ing multiple non-existent sub-node from node");
        }

        /// <summary>A test for Remove</summary>
        /// <remarks>
        /// Test: Remove a mix of existent and non-existent sub-nodes in a node that
        /// has multiple sub-nodes
        /// Expected: Returns true, existent sub-nodes are removed
        /// </remarks>
        [TestMethod]
        public void RemoveTest_MixedSubNodesInNodeWithMultipleSubNodes_True()
        {
            // Setup
            var name = "Root Node";
            var subNode1 = new Node("Sub-Node 1");
            var node = new Node(name,
                            subNode1,
                            new Node("Sub-Node 2"),
                            new Node("Sub-Node 3"));

            // Expected Values
            int expectedNodeCount = 2;

            // Actual Test
            bool result = node.Remove("Inexistent Sub-node", subNode1.Name, "Another node");

            // Verification
            Assert.IsFalse(result, "Did not return false for Remove-ing non-existent sub-nodes from node");
            Assert.IsNull(node[subNode1.Name], "Did not remove existent sub-node");
            Assert.AreEqual<int>(expectedNodeCount, node.NodesCount, "Unexpected number of nodes after Remove-ing multiple non-existent sub-node from node");
        }

        /// <summary>A test for Clear</summary>
        /// <remarks>
        /// Test: Call for a node with one sub-node
        /// Expected: All sub-nodes removed
        /// </remarks>
        [TestMethod]
        public void ClearTest_OneSubNode_GoodResult()
        {
            // Setup
            var name = "Root Node";
            var node = new Node(name,
                            new Node("Sub-Node 1"));

            // Expected Values
            int expectedNodeCount = 0;

            // Actual Test
            node.Clear();

            // Verification
            Assert.AreEqual<int>(expectedNodeCount, node.NodesCount, "Did not remove all node on Clear");
        }

        /// <summary>A test for Clear</summary>
        /// <remarks>
        /// Test: Call for a node with multiple sub-node
        /// Expected: All sub-nodes removed
        /// </remarks>
        [TestMethod]
        public void ClearTest_MultipleSubNodes_GoodResult()
        {
            // Setup
            var name = "Root Node";
            var node = new Node(name,
                            new Node("Sub-Node 1"),
                            new Node("Sub-Node 2"),
                            new Node("Sub-Node 3"));

            // Expected Values
            int expectedNodeCount = 0;

            // Actual Test
            node.Clear();

            // Verification
            Assert.AreEqual<int>(expectedNodeCount, node.NodesCount, "Did not remove all node on Clear");
        }

        /// <summary>A test for Clear</summary>
        /// <remarks>
        /// Test: Call for a node without any sub-nodes
        /// Expected: No change
        /// </remarks>
        [TestMethod]
        public void ClearTest_EmptyNode_GoodResult()
        {
            // Setup
            var name = "Root Node";
            var node = new Node(name);

            // Expected Values
            int expectedNodeCount = 0;

            // Actual Test
            node.Clear();

            // Verification
            Assert.AreEqual<int>(expectedNodeCount, node.NodesCount, "Unexpected number of sub-nodes after Clear-ing an empty node");
        }

        /// <summary>A test for Dump</summary>
        /// <remarks>
        /// Test: Dump an empty node, set indentation level to zero
        /// Expected: One line containing the node name, no indentation.
        /// </remarks>
        [TestMethod]
        public void DumpTest_NoSubNodesNoIndentation_GoodResult()
        {
            // Setup
            var name = "Root Node";
            var node = new Node(name);

            // Expected Values
            string expectedResult = name + " =>";

            // Actual Test
            string result = node.Dump(0);

            // Verification
            Assert.AreEqual<string>(expectedResult, result, "Unexpected result for Dump(0) in empty node");
        }

        /// <summary>A test for Dump</summary>
        /// <remarks>
        /// Test: Dump an empty node, set indentation level to one
        /// Expected: One line containing the node name, indented by 4 spaces
        /// </remarks>
        [TestMethod]
        public void DumpTest_NoSubNodesWithIndentation_GoodResult()
        {
            // Setup
            var name = "Root Node";
            var node = new Node(name);

            // Expected Values
            string expectedResult = "    " + name + " =>";

            // Actual Test
            string result = node.Dump(1);

            // Verification
            Assert.AreEqual<string>(expectedResult, result, "Unexpected result for Dump(1) in empty node");
        }

        /// <summary>A test for Dump</summary>
        /// <remarks>
        /// Test: Dump a node containing a single empty node, set indentation level to zero
        /// Expected: One line containing the node name, no indentation; one containing the sub-node
        /// name, one level of indentation (4 spaces)
        /// </remarks>
        [TestMethod]
        public void DumpTest_OneEmptySubNode_GoodResult()
        {
            // Setup
            var name = "Root Node";
            var subNode1Name = "SubNode1";
            var node = new Node(name,
                            new Node(subNode1Name));
            var endOfLine = " =>";

            // Expected Values
            string expectedResult = name + endOfLine + "\n" +
                                    "    " + subNode1Name + endOfLine;

            // Actual Test
            string result = node.Dump(0);

            // Verification
            Assert.AreEqual<string>(expectedResult, result, "Unexpected result for Dump(0) in node with one empty sub-node");
        }

        /// <summary>A test for Dump</summary>
        /// <remarks>
        /// Test: Dump a node containing three empty sub-node, set indentation level to zero
        /// Expected: One line containing the node name, no indentation; one additional line per
        /// sub-node name, all sub-nodes at the same level of indentation (4 spaces)
        /// </remarks>
        [TestMethod]
        public void DumpTest_MultipleEmptySubNode_GoodResult()
        {
            // Setup
            var name = "Root Node";
            var subNode1Name = "SubNode1";
            var subNode2Name = "SubNode2";
            var subNode3Name = "SubNode3";
            var node = new Node(name,
                            new Node(subNode1Name),
                            new Node(subNode2Name),
                            new Node(subNode3Name));
            var endOfLine = " =>";

            // Expected Values
            string expectedResult = name + endOfLine + "\n" +
                                    "    " + subNode1Name + endOfLine + "\n" +
                                    "    " + subNode2Name + endOfLine + "\n" +
                                    "    " + subNode3Name + endOfLine;

            // Actual Test
            string result = node.Dump(0);

            // Verification
            Assert.AreEqual<string>(expectedResult, result, "Unexpected result for Dump(0) in node with multiple empty sub-nodes");
        }

        /// <summary>A test for Dump</summary>
        /// <remarks>
        /// Test: Dump a node containing one sub-node, which contains one sub-node
        /// Expected: One line containing the node name, no indentation; one line for the sub-node
        /// name, indented at 4 spaces; one line for the sub-sub-node name, indented at 8 spaces
        /// </remarks>
        [TestMethod]
        public void DumpTest_OneSubNodeOneSubSubNode_GoodResult()
        {
            // Setup
            var name = "Root Node";
            var subNode1Name = "SubNode1";
            var subSubNode11Name = "SubNode11";
            var node = new Node(name,
                            new Node(subNode1Name,
                                new Node(subSubNode11Name)));
            var endOfLine = " =>";

            // Expected Values
            string expectedResult = name + endOfLine + "\n" +
                                    "    " + subNode1Name + endOfLine + "\n" +
                                    "        " + subSubNode11Name + endOfLine;

            // Actual Test
            string result = node.Dump(0);

            // Verification
            Assert.AreEqual<string>(expectedResult, result, "Unexpected result for Dump(0) in node with one sub-node with one empty sub-sub-node");
        }

        /// <summary>A test for Dump</summary>
        /// <remarks>
        /// Test: Dump a node containing multiple sub-nodes, some of them empty, some containing
        /// empty sub-nodes
        /// Expected: One node/sub-node name per line, indented by 4 spaces per level (first line
        /// contains the node name and is not indented)
        /// </remarks>
        [TestMethod]
        public void DumpTest_Mixed_GoodResult()
        {
            // Setup
            var name = "Root Node";
            var subNode1Name = "SubNode1";
            var subSubNode11Name = "SubNode11";
            var subNode2Name = "SubNode2";
            var subNode3Name = "SubNode3";
            var subSubNode31Name = "SubNode31";
            var subSubNode32Name = "SubNode32";
            var node = new Node(name,
                            new Node(subNode1Name,
                                new Node(subSubNode11Name)),
                            new Node(subNode2Name),
                            new Node(subNode3Name,
                                new Node(subSubNode31Name),
                                new Node(subSubNode32Name)));
            var endOfResult = " =>";
            var endOfLine = endOfResult + "\n";

            // Expected Values
            string expectedResult = name + endOfLine +
                                    "    " + subNode1Name + endOfLine +
                                    "        " + subSubNode11Name + endOfLine +
                                    "    " + subNode2Name + endOfLine +
                                    "    " + subNode3Name + endOfLine +
                                    "        " + subSubNode31Name + endOfLine +
                                    "        " + subSubNode32Name + endOfResult;

            // Actual Test
            string result = node.Dump(0);

            // Verification
            Assert.AreEqual<string>(expectedResult, result, "Unexpected result for Dump(0) in node with a mix of sub-nodes and sub-sub-nodes");
        }

        /// <summary>A test for DumpByName</summary>
        /// <remarks>
        /// Test: Dump an empty node, set indentation level to zero
        /// Expected: One line containing the node name, no indentation.
        /// </remarks>
        [TestMethod]
        public void DumpByNameTest_NoSubNodesNoIndentation_GoodResult()
        {
            // Setup
            var name = "Root Node";
            var node = new Node(name);

            // Expected Values
            string expectedResult = name + " =>";

            // Actual Test
            string result = node.DumpByName(0);

            // Verification
            Assert.AreEqual<string>(expectedResult, result, "Unexpected result for DumpByName(0) in empty node");
        }

        /// <summary>A test for DumpByName</summary>
        /// <remarks>
        /// Test: Dump an empty node, set indentation level to one
        /// Expected: One line containing the node name, indented by 4 spaces
        /// </remarks>
        [TestMethod]
        public void DumpByNameTest_NoSubNodesWithIndentation_GoodResult()
        {
            // Setup
            var name = "Root Node";
            var node = new Node(name);

            // Expected Values
            string expectedResult = "    " + name + " =>";

            // Actual Test
            string result = node.DumpByName(1);

            // Verification
            Assert.AreEqual<string>(expectedResult, result, "Unexpected result for DumpByName(1) in empty node");
        }

        /// <summary>A test for DumpByName</summary>
        /// <remarks>
        /// Test: Dump a node containing a single empty node, set indentation level to zero
        /// Expected: One line containing the node name, no indentation; one containing the sub-node
        /// name, one level of indentation (4 spaces)
        /// </remarks>
        [TestMethod]
        public void DumpByNameTest_OneEmptySubNode_GoodResult()
        {
            // Setup
            var name = "Root Node";
            var subNode1Name = "SubNode1";
            var node = new Node(name,
                            new Node(subNode1Name));
            var endOfLine = " =>";

            // Expected Values
            string expectedResult = name + endOfLine + "\n" +
                                    "    " + subNode1Name + endOfLine;

            // Actual Test
            string result = node.DumpByName(0);

            // Verification
            Assert.AreEqual<string>(expectedResult, result, "Unexpected result for DumpByName(0) in node with one empty sub-node");
        }

        /// <summary>A test for DumpByName</summary>
        /// <remarks>
        /// Test: Dump a node containing three empty sub-node, set indentation level to zero
        /// Expected: One line containing the node name, no indentation; one additional line per
        /// sub-node name, all sub-nodes at the same level of indentation (4 spaces)
        /// </remarks>
        [TestMethod]
        public void DumpByNameTest_MultipleEmptySubNode_GoodResult()
        {
            // Setup
            var name = "Root Node";
            var subNode1Name = "C_SubNode1";
            var subNode2Name = "B_SubNode2";
            var subNode3Name = "A_SubNode3";
            var node = new Node(name,
                            new Node(subNode1Name),
                            new Node(subNode2Name),
                            new Node(subNode3Name));
            var endOfLine = " =>";

            // Expected Values
            string expectedResult = name + endOfLine + "\n" +
                                    "    " + subNode3Name + endOfLine + "\n" +
                                    "    " + subNode2Name + endOfLine + "\n" +
                                    "    " + subNode1Name + endOfLine;

            // Actual Test
            string result = node.DumpByName(0);

            // Verification
            Assert.AreEqual<string>(expectedResult, result, "Unexpected result for DumpByName(0) in node with multiple empty sub-nodes");
        }

        /// <summary>A test for DumpByName</summary>
        /// <remarks>
        /// Test: Dump a node containing one sub-node, which contains one sub-node
        /// Expected: One line containing the node name, no indentation; one line for the sub-node
        /// name, indented at 4 spaces; one line for the sub-sub-node name, indented at 8 spaces
        /// </remarks>
        [TestMethod]
        public void DumpByNameTest_OneSubNodeOneSubSubNode_GoodResult()
        {
            // Setup
            var name = "Root Node";
            var subNode1Name = "Z_SubNode1";
            var subSubNode11Name = "A_SubNode11";
            var node = new Node(name,
                            new Node(subNode1Name,
                                new Node(subSubNode11Name)));
            var endOfLine = " =>";

            // Expected Values
            string expectedResult = name + endOfLine + "\n" +
                                    "    " + subNode1Name + endOfLine + "\n" +
                                    "        " + subSubNode11Name + endOfLine;

            // Actual Test
            string result = node.DumpByName(0);

            // Verification
            Assert.AreEqual<string>(expectedResult, result, "Unexpected result for DumpByName(0) in node with one sub-node with one empty sub-sub-node");
        }

        /// <summary>A test for DumpByName</summary>
        /// <remarks>
        /// Test: Dump a node containing multiple sub-nodes, some of them empty, some containing
        /// empty sub-nodes
        /// Expected: One node/sub-node name per line, indented by 4 spaces per level (first line
        /// contains the node name and is not indented)
        /// </remarks>
        [TestMethod]
        public void DumpByNameTest_Mixed_GoodResult()
        {
            // Setup
            var name = "Root Node";
            var subNode1Name = "C_SubNode1";
            var subSubNode11Name = "CA_SubNode11";
            var subNode2Name = "B_SubNode2";
            var subNode3Name = "A_SubNode3";
            var subSubNode31Name = "AZSubNode31";
            var subSubNode32Name = "AA_SubNode32";
            var node = new Node(name,
                            new Node(subNode1Name,
                                new Node(subSubNode11Name)),
                            new Node(subNode2Name),
                            new Node(subNode3Name,
                                new Node(subSubNode31Name),
                                new Node(subSubNode32Name)));
            var endOfResult = " =>";
            var endOfLine = endOfResult + "\n";

            // Expected Values
            string expectedResult = name + endOfLine +
                                    "    " + subNode3Name + endOfLine +
                                    "        " + subSubNode32Name + endOfLine +
                                    "        " + subSubNode31Name + endOfLine +
                                    "    " + subNode2Name + endOfLine +
                                    "    " + subNode1Name + endOfLine +
                                    "        " + subSubNode11Name + endOfResult;

            // Actual Test
            string result = node.DumpByName(0);

            // Verification
            Assert.AreEqual<string>(expectedResult, result, "Unexpected result for DumpByName(0) in node with a mix of sub-nodes and sub-sub-nodes");
        }

    }
}
