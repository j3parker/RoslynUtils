using System.Linq;
using NUnit.Framework;

namespace Microsoft.CodeAnalysis.CSharp.Syntax {
	[TestFixture]
	public sealed class FieldDeclarationSyntaxTests {
		[Test]
		public void AsReadOnly_MakesANonReadOnlyFieldReadOnly() {
			var field = CSharpSyntaxTree.ParseText( "public int x = 3;" )
				.GetRoot().DescendantNodes()
				.OfType<FieldDeclarationSyntax>().Single();

			Assert.IsFalse( field.IsReadOnly() );

			var roField = field.AsReadOnly();

			Assert.IsTrue( roField.IsReadOnly() );
		}

		[Test]
		public void AsReadOnly_DoesntChangeReadOnlyFields() {
			var field = CSharpSyntaxTree.ParseText( "public readonly int x = 3;" )
				.GetRoot().DescendantNodes()
				.OfType<FieldDeclarationSyntax>().Single();

			Assert.IsTrue( field.IsReadOnly() );

			var roField = field.AsReadOnly();

			Assert.AreEqual( field, roField );
		}

		private static FieldDeclarationSyntax GetField( string text ) {
			return CSharpSyntaxTree.ParseText( $"class Foo {{ {text}; }}" )
				.GetRoot().DescendantNodes()
				.OfType<FieldDeclarationSyntax>().Single();
		}
	}
}
