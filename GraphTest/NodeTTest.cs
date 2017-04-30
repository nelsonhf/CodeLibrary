using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using CodeLibrary;

namespace GraphTest
{
    /// <summary>A class to test where the id is a string</summary>
    public class StringWId : IIdentifiable<string>
    {
        private string m_content;
        public string Id
        {
            get { return m_content; }
        }
        public StringWId(string name)
        {
            m_content = name;
        }
    }

    /// <summary>A class to test where the id is an integer</summary>
    public class NumberWId : IIdentifiable<int>
    {
        private int m_id;
        private double m_aNumber;
        private string m_something;
        public int Id
        {
            get { return m_id; }
        }
        public NumberWId(int id, double number, string something)
        {
            m_id = id;
            m_aNumber = number;
            m_something = something;
        }
    }

    [TestClass]
    public class NodeTTest
    {
        /// <summary>A test for the constructor</summary>
        /// <remarks>
        /// Test: Construct with name only
        /// Expected: Normal object
        /// </remarks>
        [TestMethod]
        public void ConstructorTest_NoSubNode_Success()
        {
            // Setup
            var swi = new StringWId("Root");

            // Expected Values
            var expectedObjectType = typeof(Node<StringWId, string>);

            // Actual Test
            var node = new Node<StringWId, string>(swi);

            // Verification
            Assert.AreEqual<Type>(expectedObjectType, node.GetType(), "Wrong type constructed");
        }

        /// <summary>A test for the constructor</summary>
        /// <remarks>
        /// Test: Construct with name and one sub-node
        /// Expected: Normal object
        /// </remarks>
        [TestMethod]
        public void ConstructorTest_OneSubNode_Success()
        {
            // Setup
            var swi1 = new StringWId("Root Node");
            var swi2 = new StringWId("Sub-Node");
            var subNode1 = new Node<StringWId, string>(swi2);

            // Expected Values
            var expectedObjectType = typeof(Node<StringWId, string>);

            // Actual Test
            var node = new Node<StringWId, string>(swi1, subNode1);

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
        public void ConstructorTest_NullNode_Exception()
        {
            // Setup
            StringWId swi = null;

            // No Expected Values (should throw exception)

            // Actual Test
            var node = new Node<StringWId, string>(swi);

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
            var swi = new StringWId("Root Node");
            Node<StringWId, string> subNode = null;

            // No Expected Values (should throw exception)

            // Actual Test
            var node = new Node<StringWId, string>(swi, subNode);

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
            var swi = new StringWId("Root Node");
            Node<StringWId, string> subNode1 = null;
            var subNode2 = new Node<StringWId, string>(new StringWId("Sub-Node 2"));

            // No Expected Values (should throw exception)

            // Actual Test
            var node = new Node<StringWId, string>(swi, subNode1, subNode2);

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
            var swi = new StringWId("Root Node");
            var subNode1 = new Node<StringWId, string>(new StringWId("Sub-Node 1"));
            Node<StringWId, string> subNode2 = null;

            // No Expected Values (should throw exception)

            // Actual Test
            var node = new Node<StringWId, string>(swi, subNode1, subNode2);

            // No Verification (ExpectedException should take care of it)
        }

        /// <summary>A test for Id</summary>
        /// <remarks>
        /// Test: Property Id (where it is a string)
        /// Expected: Name set in the constructor
        /// </remarks>
        [TestMethod]
        public void IdTest_StringNormal_GoodResult()
        {
            // Setup
            var idForTest = "NodeName";
            var swi = new StringWId(idForTest);

            // Expected Values
            var expectedId = idForTest;

            // Actual Test
            var node = new Node<StringWId, string>(swi);

            // Verification
            Assert.AreEqual<string>(expectedId, node.Id, "Property Id returned wrong value");
        }

        /// <summary>A test for Id</summary>
        /// <remarks>
        /// Test: Property Id (where it is an integer)
        /// Expected: Name set in the constructor
        /// </remarks>
        [TestMethod]
        public void IdTest_IntNormal_GoodResult()
        {
            // Setup
            var idForTest = 999;
            var nwi = new NumberWId(idForTest, 123.456, "something");

            // Expected Values
            var expectedId = idForTest;

            // Actual Test
            var node = new Node<NumberWId, int>(nwi);

            // Verification
            Assert.AreEqual<int>(expectedId, node.Id, "Property Id returned wrong value");
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
            var swi = new StringWId("NodeName");
            var node = new Node<StringWId, string>(swi);

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
        public void NodesCountTest_OneSubNode_GoodResult()
        {
            // Setup
            var swi = new StringWId("NodeName");
            var subNode1 = new Node<StringWId, string>(new StringWId("Sub-Node 1"));
            var node = new Node<StringWId, string>(swi, subNode1);

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
            var swi = new StringWId("NodeName");
            var subNode1 = new Node<StringWId, string>(new StringWId("Sub-Node 1"));
            var subNode2 = new Node<StringWId, string>(new StringWId("Sub-Node 2"));
            var subNode3 = new Node<StringWId, string>(new StringWId("Sub-Node 3"));
            var node = new Node<StringWId, string>(swi, subNode1, subNode2, subNode3);

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
            var swi = new StringWId("Root Node");
            var node = new Node<StringWId, string>(swi);
            Node<StringWId, string> subNode = null;

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
            var swi = new StringWId("Root Node");
            var node = new Node<StringWId, string>(swi);
            Node<StringWId, string> subNode1 = null;
            var subNode2 = new Node<StringWId, string>(new StringWId("Sub-Node 2"));

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
            var swi = new StringWId("Root Node");
            var node = new Node<StringWId, string>(swi);
            var subNode1 = new Node<StringWId, string>(new StringWId("Sub-Node 1"));
            Node<StringWId, string> subNode2 = null;

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
            var swi = new StringWId("Root Node");
            var node = new Node<StringWId, string>(swi);
            var subNode1 = new Node<StringWId, string>(new StringWId("Sub-Node 1"));

            // Expected Values
            int expectedNodeCount = 1;

            // Actual Test
            node.Add(subNode1);
            node.Add(subNode1);

            // Verification
            Assert.IsNotNull(node[subNode1.Id], "Sub-node one not added");
            Assert.AreEqual<Node<StringWId, string>>(subNode1, node[subNode1.Id], "Node added was unexpected");
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
            var swi = new StringWId("Root Node");
            var node = new Node<StringWId, string>(swi);
            var subNode1 = new Node<StringWId, string>(new StringWId("Sub-Node 1"));
            var subNode2 = new Node<StringWId, string>(new StringWId("Sub-Node 2"));
            var subNode3 = new Node<StringWId, string>(new StringWId("Sub-Node 3"));

            // Expected Values
            int expectedNodeCount = 3;

            // Actual Test
            node.Add(subNode1);
            node.Add(subNode2);
            node.Add(subNode3);
            node.Add(subNode1);

            // Verification
            Assert.IsNotNull(node[subNode1.Id], "Sub-node one not added");
            Assert.AreEqual<Node<StringWId, string>>(subNode1, node[subNode1.Id], "Node added was unexpected");
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
            var swi = new StringWId("Root Node");
            var node = new Node<StringWId, string>(swi,
                            new Node<StringWId, string>(new StringWId("Sub-Node 1")),
                            new Node<StringWId, string>(new StringWId("Sub-Node 2")),
                            new Node<StringWId, string>(new StringWId("Sub-Node 3")));

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
            var swi = new StringWId("Root Node");
            var subNode1 = new Node<StringWId, string>(new StringWId("Sub-Node 1"));
            var node = new Node<StringWId, string>(swi,
                            subNode1,
                            new Node<StringWId, string>(new StringWId("Sub-Node 2")),
                            new Node<StringWId, string>(new StringWId("Sub-Node 3")));

            // Expected Values
            int expectedNodeCount = 2;

            // Actual Test
            bool result = node.Remove(subNode1.Id);

            // Verification
            Assert.IsTrue(result, "Did not return true for Remove-ing the first sub-node");
            Assert.IsNull(node[subNode1.Id], "Did not Remove the first sub-node");
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
            var swi = new StringWId("Root Node");
            var subNode2 = new Node<StringWId, string>(new StringWId("Sub-Node 2"));
            var node = new Node<StringWId, string>(swi,
                            new Node<StringWId, string>(new StringWId("Sub-Node 1")),
                            subNode2,
                            new Node<StringWId, string>(new StringWId("Sub-Node 3")));

            // Expected Values
            int expectedNodeCount = 2;

            // Actual Test
            bool result = node.Remove(subNode2.Id);

            // Verification
            Assert.IsTrue(result, "Did not return true for Remove-ing a sub-node");
            Assert.IsNull(node[subNode2.Id], "Did not Remove the requested sub-node");
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
            var swi = new StringWId("Root Node");
            var subNode1 = new Node<StringWId, string>(new StringWId("Sub-Node 1"));
            var subNode2 = new Node<StringWId, string>(new StringWId("Sub-Node 2"));
            var node = new Node<StringWId, string>(swi,
                            subNode1,
                            subNode2,
                            new Node<StringWId, string>(new StringWId("Sub-Node 3")));

            // Expected Values
            int expectedNodeCount = 1;

            // Actual Test
            bool result = node.Remove(subNode1.Id, subNode2.Id);

            // Verification
            Assert.IsTrue(result, "Did not return true for Remove-ing multiple sub-nodes");
            Assert.IsNull(node[subNode1.Id], "Did not Remove the requested sub-node");
            Assert.IsNull(node[subNode2.Id], "Did not Remove the requested sub-node");
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
            var swi = new StringWId("Root Node");
            var subNode1 = new Node<StringWId, string>(new StringWId("Sub-Node 1"));
            var subNode2 = new Node<StringWId, string>(new StringWId("Sub-Node 2"));
            var subNode3 = new Node<StringWId, string>(new StringWId("Sub-Node 3"));
            var node = new Node<StringWId, string>(swi,
                            subNode1,
                            subNode2,
                            subNode3);

            // Expected Values
            int expectedNodeCount = 0;

            // Actual Test
            bool result = node.Remove(subNode1.Id, subNode2.Id, subNode3.Id);

            // Verification
            Assert.IsTrue(result, "Did not return true for Remove-ing all sub-nodes");
            Assert.IsNull(node[subNode1.Id], "Did not Remove the requested sub-node");
            Assert.IsNull(node[subNode2.Id], "Did not Remove the requested sub-node");
            Assert.IsNull(node[subNode3.Id], "Did not Remove the requested sub-node");
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
            var swi = new StringWId("Root Node");
            var node = new Node<StringWId, string>(swi);

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
            var swi = new StringWId("Root Node");
            var node = new Node<StringWId, string>(swi,
                            new Node<StringWId, string>(new StringWId("Sub-Node 1")));

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
            var swi = new StringWId("Root Node");
            var node = new Node<StringWId, string>(swi,
                            new Node<StringWId, string>(new StringWId("Sub-Node 1")),
                            new Node<StringWId, string>(new StringWId("Sub-Node 2")),
                            new Node<StringWId, string>(new StringWId("Sub-Node 3")));

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
            var swi = new StringWId("Root Node");
            var node = new Node<StringWId, string>(swi,
                            new Node<StringWId, string>(new StringWId("Sub-Node 1")),
                            new Node<StringWId, string>(new StringWId("Sub-Node 2")),
                            new Node<StringWId, string>(new StringWId("Sub-Node 3")));

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
            var swi = new StringWId("Root Node");
            var subNode1 = new Node<StringWId, string>(new StringWId("Sub-Node 1"));
            var node = new Node<StringWId, string>(swi,
                            subNode1,
                            new Node<StringWId, string>(new StringWId("Sub-Node 2")),
                            new Node<StringWId, string>(new StringWId("Sub-Node 3")));

            // Expected Values
            int expectedNodeCount = 2;

            // Actual Test
            bool result = node.Remove("Inexistent Sub-node", subNode1.Id, "Another node");

            // Verification
            Assert.IsFalse(result, "Did not return false for Remove-ing non-existent sub-nodes from node");
            Assert.IsNull(node[subNode1.Id], "Did not remove existent sub-node");
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
            var swi = new StringWId("Root Node");
            var node = new Node<StringWId, string>(swi,
                            new Node<StringWId, string>(new StringWId("Sub-Node 1")));

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
            var swi = new StringWId("Root Node");
            var node = new Node<StringWId, string>(swi,
                            new Node<StringWId, string>(new StringWId("Sub-Node 1")),
                            new Node<StringWId, string>(new StringWId("Sub-Node 2")),
                            new Node<StringWId, string>(new StringWId("Sub-Node 3")));

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
            var swi = new StringWId("Root Node");
            var node = new Node<StringWId, string>(swi);

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
            var swi = new StringWId("Root Node");
            var node = new Node<StringWId, string>(swi);

            // Expected Values
            string expectedResult = swi.Id + " =>";

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
            var swi = new StringWId("Root Node");
            var node = new Node<StringWId, string>(swi);

            // Expected Values
            string expectedResult = "    " + swi.Id + " =>";

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
            var swi = new StringWId("Root Node");
            var subNode1Name = "SubNode1";
            var node = new Node<StringWId, string>(swi,
                            new Node<StringWId, string>(new StringWId(subNode1Name)));
            var endOfLine = " =>";

            // Expected Values
            string expectedResult = swi.Id + endOfLine + "\n" +
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
            var swi = new StringWId("Root Node");
            var subNode1Name = "SubNode1";
            var subNode2Name = "SubNode2";
            var subNode3Name = "SubNode3";
            var node = new Node<StringWId, string>(swi,
                            new Node<StringWId, string>(new StringWId(subNode1Name)),
                            new Node<StringWId, string>(new StringWId(subNode2Name)),
                            new Node<StringWId, string>(new StringWId(subNode3Name)));
            var endOfLine = " =>";

            // Expected Values
            string expectedResult = swi.Id + endOfLine + "\n" +
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
            var swi = new StringWId("Root Node");
            var subNode1Name = "SubNode1";
            var subSubNode11Name = "SubNode11";
            var node = new Node<StringWId, string>(swi,
                            new Node<StringWId, string>(new StringWId(subNode1Name),
                                new Node<StringWId, string>(new StringWId(subSubNode11Name))));
            var endOfLine = " =>";

            // Expected Values
            string expectedResult = swi.Id + endOfLine + "\n" +
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
        /// empty sub-nodes (id is a string)
        /// Expected: One node/sub-node name per line, indented by 4 spaces per level (first line
        /// contains the node name and is not indented)
        /// </remarks>
        [TestMethod]
        public void DumpTest_StringMixed_GoodResult()
        {
            // Setup
            var swi = new StringWId("Root Node");
            var subNode1Name = "SubNode1";
            var subSubNode11Name = "SubNode11";
            var subNode2Name = "SubNode2";
            var subNode3Name = "SubNode3";
            var subSubNode31Name = "SubNode31";
            var subSubNode32Name = "SubNode32";
            var node = new Node<StringWId, string>(swi,
                            new Node<StringWId, string>(new StringWId(subNode1Name),
                                new Node<StringWId, string>(new StringWId(subSubNode11Name))),
                            new Node<StringWId, string>(new StringWId(subNode2Name)),
                            new Node<StringWId, string>(new StringWId(subNode3Name),
                                new Node<StringWId, string>(new StringWId(subSubNode31Name)),
                                new Node<StringWId, string>(new StringWId(subSubNode32Name))));
            var endOfResult = " =>";
            var endOfLine = endOfResult + "\n";

            // Expected Values
            string expectedResult = swi.Id + endOfLine +
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

        /// <summary>A test for Dump</summary>
        /// <remarks>
        /// Test: Dump a node containing multiple sub-nodes, some of them empty, some containing
        /// empty sub-nodes (id is a number)
        /// Expected: One node/sub-node name per line, indented by 4 spaces per level (first line
        /// contains the node name and is not indented)
        /// </remarks>
        [TestMethod]
        public void DumpTest_IntMixed_GoodResult()
        {
            // Setup
            var swi = new NumberWId(0, 0.1, "_");
            var subNode1Id = 1;
            var subSubNode11Id = 11;
            var subNode2Id = 2;
            var subNode3Id = 3;
            var subSubNode31Id = 31;
            var subSubNode32Id = 32;
            var node = new Node<NumberWId, int>(swi,
                            new Node<NumberWId, int>(new NumberWId(subNode1Id, 1.1, "a"),
                                new Node<NumberWId, int>(new NumberWId(subSubNode11Id, 11.11, "aa"))),
                            new Node<NumberWId, int>(new NumberWId(subNode2Id, 2.2, "b")),
                            new Node<NumberWId, int>(new NumberWId(subNode3Id, 3.3, "c"),
                                new Node<NumberWId, int>(new NumberWId(subSubNode31Id, 31.31, "ca")),
                                new Node<NumberWId, int>(new NumberWId(subSubNode32Id, 32.32, "cb"))));
            var endOfResult = " =>";
            var endOfLine = endOfResult + "\n";

            // Expected Values
            string expectedResult = swi.Id + endOfLine +
                                    "    " + subNode1Id + endOfLine +
                                    "        " + subSubNode11Id + endOfLine +
                                    "    " + subNode2Id + endOfLine +
                                    "    " + subNode3Id + endOfLine +
                                    "        " + subSubNode31Id + endOfLine +
                                    "        " + subSubNode32Id + endOfResult;

            // Actual Test
            string result = node.Dump(0);

            // Verification
            Assert.AreEqual<string>(expectedResult, result, "Unexpected result for Dump(0) in node with a mix of sub-nodes and sub-sub-nodes");
        }

        /// <summary>A test for DumpById</summary>
        /// <remarks>
        /// Test: Dump an empty node, set indentation level to zero
        /// Expected: One line containing the node name, no indentation.
        /// </remarks>
        [TestMethod]
        public void DumpByIdTest_NoSubNodesNoIndentation_GoodResult()
        {
            // Setup
            var swi = new StringWId("Root Node");
            var node = new Node<StringWId, string>(swi);

            // Expected Values
            string expectedResult = swi.Id + " =>";

            // Actual Test
            string result = node.DumpById(0);

            // Verification
            Assert.AreEqual<string>(expectedResult, result, "Unexpected result for DumpById(0) in empty node");
        }

        /// <summary>A test for DumpById</summary>
        /// <remarks>
        /// Test: Dump an empty node, set indentation level to one
        /// Expected: One line containing the node name, indented by 4 spaces
        /// </remarks>
        [TestMethod]
        public void DumpByIdTest_NoSubNodesWithIndentation_GoodResult()
        {
            // Setup
            var swi = new StringWId("Root Node");
            var node = new Node<StringWId, string>(swi);

            // Expected Values
            string expectedResult = "    " + swi.Id + " =>";

            // Actual Test
            string result = node.DumpById(1);

            // Verification
            Assert.AreEqual<string>(expectedResult, result, "Unexpected result for DumpById(1) in empty node");
        }

        /// <summary>A test for DumpById</summary>
        /// <remarks>
        /// Test: Dump a node containing a single empty node, set indentation level to zero
        /// Expected: One line containing the node name, no indentation; one containing the sub-node
        /// name, one level of indentation (4 spaces)
        /// </remarks>
        [TestMethod]
        public void DumpByIdTest_OneEmptySubNode_GoodResult()
        {
            // Setup
            var swi = new StringWId("Root Node");
            var subNode1Name = "SubNode1";
            var node = new Node<StringWId, string>(swi,
                            new Node<StringWId, string>(new StringWId(subNode1Name)));
            var endOfLine = " =>";

            // Expected Values
            string expectedResult = swi.Id + endOfLine + "\n" +
                                    "    " + subNode1Name + endOfLine;

            // Actual Test
            string result = node.DumpById(0);

            // Verification
            Assert.AreEqual<string>(expectedResult, result, "Unexpected result for DumpById(0) in node with one empty sub-node");
        }

        /// <summary>A test for DumpById</summary>
        /// <remarks>
        /// Test: Dump a node containing three empty sub-node, set indentation level to zero
        /// Expected: One line containing the node name, no indentation; one additional line per
        /// sub-node name, all sub-nodes at the same level of indentation (4 spaces)
        /// </remarks>
        [TestMethod]
        public void DumpByIdTest_MultipleEmptySubNode_GoodResult()
        {
            // Setup
            var swi = new StringWId("Root Node");
            var subNode1Name = "C_SubNode1";
            var subNode2Name = "B_SubNode2";
            var subNode3Name = "A_SubNode3";
            var node = new Node<StringWId, string>(swi,
                            new Node<StringWId, string>(new StringWId(subNode1Name)),
                            new Node<StringWId, string>(new StringWId(subNode2Name)),
                            new Node<StringWId, string>(new StringWId(subNode3Name)));
            var endOfLine = " =>";

            // Expected Values
            string expectedResult = swi.Id + endOfLine + "\n" +
                                    "    " + subNode3Name + endOfLine + "\n" +
                                    "    " + subNode2Name + endOfLine + "\n" +
                                    "    " + subNode1Name + endOfLine;

            // Actual Test
            string result = node.DumpById(0);

            // Verification
            Assert.AreEqual<string>(expectedResult, result, "Unexpected result for DumpById(0) in node with multiple empty sub-nodes");
        }

        /// <summary>A test for DumpById</summary>
        /// <remarks>
        /// Test: Dump a node containing one sub-node, which contains one sub-node
        /// Expected: One line containing the node name, no indentation; one line for the sub-node
        /// name, indented at 4 spaces; one line for the sub-sub-node name, indented at 8 spaces
        /// </remarks>
        [TestMethod]
        public void DumpByIdTest_OneSubNodeOneSubSubNode_GoodResult()
        {
            // Setup
            var swi = new StringWId("Root Node");
            var subNode1Name = "Z_SubNode1";
            var subSubNode11Name = "A_SubNode11";
            var node = new Node<StringWId, string>(swi,
                            new Node<StringWId, string>(new StringWId(subNode1Name),
                                new Node<StringWId, string>(new StringWId(subSubNode11Name))));
            var endOfLine = " =>";

            // Expected Values
            string expectedResult = swi.Id + endOfLine + "\n" +
                                    "    " + subNode1Name + endOfLine + "\n" +
                                    "        " + subSubNode11Name + endOfLine;

            // Actual Test
            string result = node.DumpById(0);

            // Verification
            Assert.AreEqual<string>(expectedResult, result, "Unexpected result for DumpById(0) in node with one sub-node with one empty sub-sub-node");
        }

        /// <summary>A test for DumpById</summary>
        /// <remarks>
        /// Test: Dump a node containing multiple sub-nodes, some of them empty, some containing
        /// empty sub-nodes
        /// Expected: One node/sub-node name per line, indented by 4 spaces per level (first line
        /// contains the node name and is not indented)
        /// </remarks>
        [TestMethod]
        public void DumpByIdTest_Mixed_GoodResult()
        {
            // Setup
            var swi = new StringWId("Root Node");
            var subNode1Name = "C_SubNode1";
            var subSubNode11Name = "CA_SubNode11";
            var subNode2Name = "B_SubNode2";
            var subNode3Name = "A_SubNode3";
            var subSubNode31Name = "AZSubNode31";
            var subSubNode32Name = "AA_SubNode32";
            var node = new Node<StringWId, string>(swi,
                            new Node<StringWId, string>(new StringWId(subNode1Name),
                                new Node<StringWId, string>(new StringWId(subSubNode11Name))),
                            new Node<StringWId, string>(new StringWId(subNode2Name)),
                            new Node<StringWId, string>(new StringWId(subNode3Name),
                                new Node<StringWId, string>(new StringWId(subSubNode31Name)),
                                new Node<StringWId, string>(new StringWId(subSubNode32Name))));
            var endOfResult = " =>";
            var endOfLine = endOfResult + "\n";

            // Expected Values
            string expectedResult = swi.Id + endOfLine +
                                    "    " + subNode3Name + endOfLine +
                                    "        " + subSubNode32Name + endOfLine +
                                    "        " + subSubNode31Name + endOfLine +
                                    "    " + subNode2Name + endOfLine +
                                    "    " + subNode1Name + endOfLine +
                                    "        " + subSubNode11Name + endOfResult;

            // Actual Test
            string result = node.DumpById(0);

            // Verification
            Assert.AreEqual<string>(expectedResult, result, "Unexpected result for DumpById(0) in node with a mix of sub-nodes and sub-sub-nodes");
        }
        /// <summary>A test for Dump</summary>
        /// <remarks>
        /// Test: Dump a node containing multiple sub-nodes, some of them empty, some containing
        /// empty sub-nodes (id is a number)
        /// Expected: One node/sub-node name per line, indented by 4 spaces per level (first line
        /// contains the node name and is not indented)
        /// </remarks>
        [TestMethod]
        public void DumpByIdTest_IntMixed_GoodResult()
        {
            // Setup
            var swi = new NumberWId(70, 0.1, "_");
            var subNode1Id = 61;
            var subSubNode11Id = 511;
            var subNode2Id = 42;
            var subNode3Id = 33;
            var subSubNode31Id = 231;
            var subSubNode32Id = 132;
            var node = new Node<NumberWId, int>(swi,
                            new Node<NumberWId, int>(new NumberWId(subNode1Id, 1.1, "a"),
                                new Node<NumberWId, int>(new NumberWId(subSubNode11Id, 11.11, "aa"))),
                            new Node<NumberWId, int>(new NumberWId(subNode2Id, 2.2, "b")),
                            new Node<NumberWId, int>(new NumberWId(subNode3Id, 3.3, "c"),
                                new Node<NumberWId, int>(new NumberWId(subSubNode31Id, 31.31, "ca")),
                                new Node<NumberWId, int>(new NumberWId(subSubNode32Id, 32.32, "cb"))));
            var endOfResult = " =>";
            var endOfLine = endOfResult + "\n";

            // Expected Values
            string expectedResult = swi.Id + endOfLine +
                                    "    " + subNode3Id + endOfLine +
                                    "        " + subSubNode32Id + endOfLine +
                                    "        " + subSubNode31Id + endOfLine +
                                    "    " + subNode2Id + endOfLine +
                                    "    " + subNode1Id + endOfLine +
                                    "        " + subSubNode11Id + endOfResult;

            // Actual Test
            string result = node.DumpById(0);

            // Verification
            Assert.AreEqual<string>(expectedResult, result, "Unexpected result for Dump(0) in node with a mix of sub-nodes and sub-sub-nodes");
        }


    }
}
