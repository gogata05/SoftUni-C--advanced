const { expect } = require('chai');
const weddingDay = require('./weddingDay'); 

describe("weddingDay", function() {
    describe("pickVenue", function() {
        it("should throw error for invalid input", function() {
            expect(() => weddingDay.pickVenue('a', 100, 'Varna')).to.throw("Invalid Information!");
        });

        it("should throw error for incorrect location", function() {
            expect(() => weddingDay.pickVenue(150, 100, 'Sofia')).to.throw("The location of this venue is not in the correct area!");
        });

        it("should return correct message for valid input", function() {
            expect(weddingDay.pickVenue(150, 100, 'Varna')).to.equal("This venue meets the requirements, with capacity of 150 guests and 100$ cover.");
        });

        it("should return correct message for invalid requirements", function() {
            expect(weddingDay.pickVenue(100, 100, 'Varna')).to.equal("This venue does not meet your requirements!");
        });
    });

    describe("otherSpendings", function() {
        it("should throw error for invalid input", function() {
            expect(() => weddingDay.otherSpendings('flowers', 'pictures', true)).to.throw("Invalid Information!");
        });

        it("should return correct message with discount", function() {
            expect(weddingDay.otherSpendings(['flowers'], ['pictures'], true)).to.equal("You spend 1020$ for wedding decoration and photography with 15% discount!");
        });

        it("should return correct message without discount", function() {
            expect(weddingDay.otherSpendings(['flowers'], ['pictures'], false)).to.equal("You spend 1200$ for wedding decoration and photography!");
        });
    });

    describe("tableDistribution", function() {
        it("should throw error for invalid input", function() {
            expect(() => weddingDay.tableDistribution('a', 5)).to.throw("Invalid Information!");
        });

        it("should return correct message for less than 6 people on table", function() {
            expect(weddingDay.tableDistribution(10, 2)).to.equal("There is only 5 people on every table, you can join some tables.");
        });

        it("should return correct message for 6 or more people on table", function() {
            expect(weddingDay.tableDistribution(12, 2)).to.equal("You have 2 tables with 6 guests on table.");
        });
    });
});
