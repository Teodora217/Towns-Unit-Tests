using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TownsTests
{
    public class TownsCollectionTests
    {
        public TownsCollection townCollectionOne;
        public TownsCollection townCollectionTwo;

        [SetUp]
        public void Setup()
        {
            this.townCollectionOne = new TownsCollection("Paris");
            this.townCollectionTwo = new TownsCollection("Paris, London");
        }
        [Test]
        public void Test_Constructor_EmptyConstructor()
        {
            var townCollection = new TownsCollection();
            Assert.That(townCollection.Towns.Count, Is.EqualTo(0));
            Assert.That(townCollection.ToString(), Is.Empty);

        }
        [Test]
        public void Test_Constructor_SingleTown()
        {
            var townCollection = new TownsCollection("Paris");
            Assert.That(townCollection.Towns.Count, Is.EqualTo(1));
            Assert.That(townCollection.ToString(), Is.EqualTo("Paris"));

        }

        [Test]
        public void Test_Constructor_TwoTowns()
        {

            Assert.That(this.townCollectionTwo.Towns.Count, Is.EqualTo(2));
            Assert.That(this.townCollectionTwo.ToString(), Is.EqualTo("Paris, London"));

        }

        [Test]
        public void Test_Add_SingleTown()
        {

            this.townCollectionTwo.Add("Sofia");
            Assert.That(townCollectionTwo.Towns.Count, Is.EqualTo(3));
            Assert.That(townCollectionTwo.ToString(), Is.EqualTo("Paris, London, Sofia"));

        }
        [Test]
        public void Test_Add_SingleAlternative()
        {

            var isAdded = this.townCollectionTwo.Add("Sofia");
            Assert.True(isAdded);

        }
        [Test]
        public void Test_Add_DuplicateAlternative()
        {

            var isAdded = this.townCollectionTwo.Add("Paris");
            Assert.False(isAdded);

        }
        [Test]
        public void Test_Add_EmptyTown()
        {

            this.townCollectionTwo.Add("");
            Assert.That(townCollectionTwo.Towns.Count, Is.EqualTo(2));
            Assert.That(townCollectionTwo.ToString(), Is.EqualTo("Paris, London"));

        }
        [Test]
        public void Test_Add_DuplicateTown()
        {

            this.townCollectionTwo.Add("Paris");
            Assert.That(this.townCollectionTwo.Towns.Count, Is.EqualTo(2));
            Assert.That(this.townCollectionTwo.ToString(), Is.EqualTo("Paris, London"));

        }
        [Test]
        public void Test_RemoveAtIndex_ValidIndex()
        {

            this.townCollectionTwo.RemoveAt(0);
            Assert.That(this.townCollectionTwo.Towns.Count, Is.EqualTo(1));
            Assert.That(this.townCollectionTwo.ToString(), Is.EqualTo("London"));

        }
        [Test]
        public void Test_RemoveAtIndex_InValidIndex()
        {
            Assert.That(() => this.townCollectionTwo.RemoveAt(5), Throws.InstanceOf<ArgumentException>());

        }
        [Test]
        public void Test_Reverse_TwoTowns()
        {

            this.townCollectionTwo.Reverse();
            Assert.That(this.townCollectionTwo.Towns.Count, Is.EqualTo(2));
            Assert.That(this.townCollectionTwo.ToString(), Is.EqualTo("London, Paris"));

        }
        [Test]
        public void Test_Reverse_SingleTown()
        {
            Assert.That(() => this.townCollectionOne.Reverse(), Throws.InstanceOf<InvalidOperationException>());

        }
        [Test]
        public void Test_Reverse_ZeroTown()
        {
            var townCollection = new TownsCollection();
            townCollection.Towns = null;
            Assert.That(() => townCollection.Reverse(), Throws.InstanceOf<ArgumentNullException>());

        }
    }
}
