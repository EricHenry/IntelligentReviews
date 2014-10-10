package edu.umassd.polarity;

import java.util.List;

import org.junit.Assert;
import org.junit.Test;

public class PolarityExtracterTest
{
	@Test
	public void verifySentence()
	{
		String sentence = "Forward-thinking. It's ironic that Apple's marketing slogan for the iPhone 5s invites us to look ahead to the future when, from the outside, the device looks like a carbon copy of last year's model, the iPhone 5. But just like any other odd-year iPhone -- the \"S\" version, if you will -- the 5s plays the Transformers card by offering more than meets the eye, with a few key improvements on the inside.";
		String posWords = "like like improvements";
		String negWords = "ironic";
		PolarityExtracter ex = PolarityExtracter.create(sentence, posWords,
				negWords);

		List<String> content = ex.extract();

		Assert.assertEquals(4, content.size());

		Assert.assertEquals("outside, the device looks like a carbon",
				content.get(0));
		Assert.assertEquals("iPhone 5. But just like any other", content.get(1));
		Assert.assertEquals("with a few key improvements on the", content.get(2));
		Assert.assertEquals("Forward-thinking. It's ironic that Apple's", content.get(3));
	}
}
