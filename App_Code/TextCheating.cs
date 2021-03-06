﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

public enum ExampleArticles { KnowledgeAndSocialNetworks, NotAllIsGoldThatGlitters, HackersTopologyMatterGeography }
public enum KeywordResources { IEEE, INSPEC_Controlled, INSPEC_Non_Controlled, Author, ALL }
/// <summary>
/// Summary description for TextCheating
/// </summary>
public class TextCheating
{
    public TextCheating()
    {
        //
        // TODO: Add constructor logic here
        //
    }
    public string stopWordsPath;
    public IList<string> StopList()
    {
        string stopwords;
        #region words
        stopwords = @"a
a's
able
about
above
according
accordingly
across
actually
after
afterwards
again
against
ain't
all
allow
allows
almost
alone
along
already
also
although
always
am
among
amongst
an
and
another
any
anybody
anyhow
anyone
anything
anyway
anyways
anywhere
apart
appear
appreciate
appropriate
are
aren't
around
as
aside
ask
asking
associated
at
available
away
awfully
b
be
became
because
become
becomes
becoming
been
before
beforehand
behind
being
believe
below
beside
besides
best
better
between
beyond
both
brief
but
by
c
c'mon
c's
came
can
can't
cannot
cant
cause
causes
certain
certainly
changes
clearly
co
com
come
comes
concerning
consequently
consider
considering
contain
containing
contains
corresponding
could
couldn't
course
currently
d
definitely
described
despite
did
didn't
different
do
does
doesn't
doing
don't
done
down
downwards
during
e
each
edu
eg
eight
either
else
elsewhere
enough
entirely
especially
et
etc
even
ever
every
everybody
everyone
everything
everywhere
ex
exactly
example
except
f
far
few
fifth
first
five
followed
following
follows
for
former
formerly
forth
four
from
further
furthermore
g
get
gets
getting
given
gives
go
goes
going
gone
got
gotten
greetings
h
had
hadn't
happens
hardly
has
hasn't
have
haven't
having
he
he's
hello
help
hence
her
here
here's
hereafter
hereby
herein
hereupon
hers
herself
hi
him
himself
his
hither
hopefully
how
howbeit
however
i
i'd
i'll
i'm
i've
ie
if
ignored
immediate
in
inasmuch
inc
indeed
indicate
indicated
indicates
inner
insofar
instead
into
inward
is
isn't
it
it'd
it'll
it's
its
itself
j
just
k
keep
keeps
kept
know
knows
known
l
last
lately
later
latter
latterly
least
less
lest
let
let's
like
liked
likely
little
look
looking
looks
ltd
m
mainly
many
may
maybe
me
mean
meanwhile
merely
might
more
moreover
most
mostly
much
must
my
myself
n
name
namely
nd
near
nearly
necessary
need
needs
neither
never
nevertheless
new
next
nine
no
nobody
non
none
noone
nor
normally
not
nothing
novel
now
nowhere
o
obviously
of
off
often
oh
ok
okay
old
on
once
one
ones
only
onto
or
other
others
otherwise
ought
our
ours
ourselves
out
outside
over
overall
own
p
particular
particularly
per
perhaps
placed
please
plus
possible
presumably
probably
provides
q
que
quite
qv
r
rather
rd
re
really
reasonably
regarding
regardless
regards
relatively
respectively
right
s
said
same
saw
say
saying
says
second
secondly
see
seeing
seem
seemed
seeming
seems
seen
self
selves
sensible
sent
serious
seriously
seven
several
shall
she
should
shouldn't
since
six
so
some
somebody
somehow
someone
something
sometime
sometimes
somewhat
somewhere
soon
sorry
specified
specify
specifying
still
sub
such
sup
sure
t
t's
take
taken
tell
tends
th
than
thank
thanks
thanx
that
that's
thats
the
their
theirs
them
themselves
then
thence
there
there's
thereafter
thereby
therefore
therein
theres
thereupon
these
they
they'd
they'll
they're
they've
think
third
this
thorough
thoroughly
those
though
three
through
throughout
thru
thus
to
together
too
took
toward
towards
tried
tries
truly
try
trying
twice
two
u
un
under
unfortunately
unless
unlikely
until
unto
up
upon
us
use
used
useful
uses
using
usually
uucp
v
value
various
very
via
viz
vs
w
want
wants
was
wasn't
way
we
we'd
we'll
we're
we've
welcome
well
went
were
weren't
what
what's
whatever
when
whence
whenever
where
where's
whereafter
whereas
whereby
wherein
whereupon
wherever
whether
which
while
whither
who
who's
whoever
whole
whom
whose
why
will
willing
wish
with
within
without
won't
wonder
would
would
wouldn't
x
y
yes
yet
you
you'd
you'll
you're
you've
your
yours
yourself
yourselves
z
zero";



        #endregion


        return stopwords.Split(' '); ;
    }

    public IList<string> StopListFromFile()
    {
        string[] res = File.ReadAllLines(stopWordsPath);
        return res;
    }

    public string Sample1()
    {
        string sample1 = @"Compatibility of systems of linear constraints over the set of natural numbers. 
Criteria of compatibility of a system of linear Diophantine equations, strict inequations, and nonstrict inequations are considered. 
Upper bounds for components of a minimal set of solutions and algorithms of construction of minimal generating sets of solutions for all types of systems are given. 
These criteria and the corresponding algorithms for constructing a minimal supporting set of solutions can be used in solving all the considered types of systems and systems of mixed types.";

        return sample1;
    }

    public IList<string> ExpectedSample1()
    {
        List<string> expected = new List<string>();

        // expected by Benmcevoy
        /*
         * Keyword:  minimal generating sets , score:  8.66666666667
        Keyword:  linear diophantine equations , score:  8.5
        Keyword:  minimal supporting set , score:  7.66666666667
        Keyword:  minimal set , score:  4.66666666667
        Keyword:  linear constraints , score:  4.5
        Keyword:  upper bounds , score:  4.0
        Keyword:  natural numbers , score:  4.0
        Keyword:  nonstrict inequations , score:  4.0
        */
        expected.Add("linear diophantine equations");
        expected.Add("minimal supporting set");
        expected.Add("minimal set");
        expected.Add("linear constraints");
        expected.Add("upper bound");
        expected.Add("natural numbers");
        expected.Add("nonstrict inequations");

        return expected;
    }

    /// <summary>
    /// Knowledge and Social Networks in Yahoo! Answers
    /// </summary>
    /// <returns>All keywords </returns>
    public IList<string> ExpectedKeywords(ExampleArticles article, KeywordResources resource)
    {
        string path = HttpContext.Current.Server.MapPath(".") + "/Files/Amit Article Text/Online Keywords/";
        switch (article)
        {
            case ExampleArticles.KnowledgeAndSocialNetworks:
                path += "Knowledge and Social Networks.txt";
                break;
            case ExampleArticles.NotAllIsGoldThatGlitters:
                path += "Not All Is Gold That Glitters .txt";
                break;
            case ExampleArticles.HackersTopologyMatterGeography:
                path += "Hackers topology matter geography.txt";
                break;
            default:
                break;
        }
        List<string> ieee = new List<string>();
        List<string> inspec_controlled = new List<string>();
        List<string> inspec_non_controlled = new List<string>();
        List<string> author = new List<string>();
        string[] res = File.ReadAllLines(path);
        for (int i = 0; i < res.Length - 1; i++)
        {
            if (res[i].ToLower().Trim().Contains("ieee"))
            {
                ieee = res[i + 1].ToLower().Trim().Split(',').ToList();
            }
            else if (res[i].ToLower().Trim().Contains("inspec - controlled"))
            {
                inspec_controlled = res[i + 1].ToLower().Trim().Split(',').ToList();
            }
            else if (res[i].ToLower().Trim().Contains("inspec - non"))
            {
                inspec_non_controlled = res[i + 1].ToLower().Trim().Split(',').ToList();
            }
            else if (res[i].ToLower().Trim().Contains("author keywords"))
            {
                author = res[i + 1].ToLower().Trim().Split(',').ToList();
            }
        }

        switch (resource)
        {
            case KeywordResources.IEEE:
                return ieee;

            case KeywordResources.INSPEC_Controlled:
                return inspec_controlled;
            case KeywordResources.INSPEC_Non_Controlled:
                return inspec_non_controlled;
            case KeywordResources.Author:
                return author;
            case KeywordResources.ALL:
                List<string> all = new List<string>();
                all.AddRange(ieee);
                all.AddRange(inspec_controlled);
                all.AddRange(inspec_non_controlled);
                all.AddRange(author);
                return all;
            default:
                return null;
        }

    }

    public string GetArticleText(ExampleArticles article)
    {
        string path = HttpContext.Current.Server.MapPath(".") + "/Files/Amit Article Text/";
        switch (article)
        {
            case ExampleArticles.KnowledgeAndSocialNetworks:
                path += "knowledge_and_Social_Networks_in_Yahoo_Answers_HICSS_12092011.txt";
                break;
            case ExampleArticles.NotAllIsGoldThatGlitters:
                path += "Not_all_is_Gold_that_Glitters_Response_t.txt";
                break;
            case ExampleArticles.HackersTopologyMatterGeography:
                path += "Hackers_Topology_Matter_Geography.txt";
                break;
            default:
                break;
        }
        return File.ReadAllText(path);

    }

   public List<string> BestResultsOnHackers()
    {
        /*
         * To get these results i used to following paremerts: Rake.Run(minimumCharLength, maximumWordsLength, minimumWordsFrequency)
         * 4 and 3 words phrases: rake.run(1, 4, 2)
         * 2 words phrases: rake.run(1,2,2) - i think i should have went with 1,2,3 
         * 1 word keywords: rake.run(1,1,7) -- i dont think 8 would be good enough
         */

        string resultStr = "";
        #region results string
        resultStr += @"successful brute force attacks
2015 ieee/acm international conference
system trespassing events
dynamic social networks
social networks analysis
online social networks
israeli hp networks
data collection period
street segments
justice statistics
geographic positions
betweenness centrality
geographic distance
real world
geographical distance
system trespassing
geographic location
trespassing event
university press
israeli hp
authority centrality
topological positions
trespassing events
“major players”
american journal
main countries
physical distance
hacking activities
sans institute
social science
hacking activity
main nodes
social networks
system trespassers
top hub
degree centrality
international journal
israeli networks
target computer
collected information
centrality” countries
ip address
unique countries
target computers
israeli network
attacking computers
follow onnela
total number
ip addresses
hacking countries
hacking networks
sessions relation
united states
computer networks
chinese hp
hacking data
network analysis
attacks originated
network topology
chinese network
graph 1
graph 2
graph 5
graph 6
graph 8
graph 9
graph 10
figures 1
figure 1
figure 2
figure 3
table 1
& cukier
hp
hacking
system
computers
study
countries
networks
sessions
research
network
nodes
internet
data
hackers
topology
geography
cyberspace
chinese
structure
number
attacks
attackers
country
found
honey
present
bfa
pots
israel
behavior
influence
china
links
advances
mining
al
topologies
";
        #endregion

        string[] testing = resultStr.Split('\n');
        return testing.ToList();

    }
}